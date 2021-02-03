using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4.BLL.Scheduler
{
    // Предоставляет планировщик задач, который обеспечивает максимальный уровень параллелизма при работе поверх пула потоков. 
    public class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
    {
        // Указывает, обрабатывает ли текущий поток рабочие элементы. 
        [ThreadStatic]
        private static bool _currentThreadIsProcessingItems;

        // Список задач к выполнению 
        private readonly LinkedList<Task> _tasks = new LinkedList<Task>(); // protected by lock(_tasks)

        //Максимальный уровень параллелизма, разрешенный этим планировщиком.
        private readonly int _maxDegreeOfParallelism;

        // Указывает, обрабатывает ли планировщик в настоящее время рабочие элементы. 
        private int _delegatesQueuedOrRunning = 0;

        // Создает новый экземпляр с указанной степенью параллелизма. 
        public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism < 1)
            {
                throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
            }
            _maxDegreeOfParallelism = maxDegreeOfParallelism;
        }

        //Ставит задачу в очередь планировщику. 
        protected sealed override void QueueTask(Task task)
        {
            //Добавьте задачу в список задач, которые нужно обработать. Если в очереди или запущенных
            //в данный момент делегатов недостаточно для обработки задач, запланируйте другой. 
            lock (_tasks)
            {
                _tasks.AddLast(task);
                if (_delegatesQueuedOrRunning < _maxDegreeOfParallelism)
                {
                    ++_delegatesQueuedOrRunning;
                    NotifyThreadPoolOfPendingWork();
                }
            }
        }

        // Сообщите ThreadPool, что для этого планировщика нужно выполнить работу. 
        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
            {
                // Обратите внимание, что текущий поток сейчас обрабатывает рабочие элементы.
                // Это необходимо для включения встраивания задач в этот поток. 
                _currentThreadIsProcessingItems = true;
                try
                {
                    // Обработать все доступные элементы в очереди.
                    while (true)
                    {
                        Task item;
                        lock (_tasks)
                        {
                            // Когда больше нет элементов для обработки, обратите
                            // внимание, что мы закончили обработку, и уходите. 
                            if (_tasks.Count == 0)
                            {
                                --_delegatesQueuedOrRunning;
                                break;
                            }

                            // Получить следующий элемент из очереди 
                            item = _tasks.First.Value;
                            _tasks.RemoveFirst();
                        }

                        // Выполнить задачу, которую мы вытащили из очереди 
                        base.TryExecuteTask(item);
                    }
                }
                // Мы закончили обработку элементов в текущем потоке 
                finally 
                { 
                    _currentThreadIsProcessingItems = false; 
                }
            }, null);
        }

        // Пытается выполнить указанную задачу в текущем потоке. 
        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // Если этот поток еще не обрабатывает задачу, мы не поддерживаем встраивание 
            if (!_currentThreadIsProcessingItems)
            {
                return false;
            }

            // Если задача ранее была поставлена в очередь, удалите ее из очереди 
            if (taskWasPreviouslyQueued)
                // Попробуйте запустить задачу. 
                if (TryDequeue(task))
                {
                    return base.TryExecuteTask(task);
                }
                else
                {
                    return false;
                }
            else
            {
                return base.TryExecuteTask(task);
            }
        }

        // Попытка удалить из планировщика ранее запланированную задачу.
        protected sealed override bool TryDequeue(Task task)
        {
            lock (_tasks)
            {
                return _tasks.Remove(task);
            }
        }

        // Получает максимальный уровень параллелизма, поддерживаемый этим планировщиком. 
        public sealed override int MaximumConcurrencyLevel { get { return _maxDegreeOfParallelism; } }

        // Получает перечисление задач, запланированных в данный момент в этом планировщике.
        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(_tasks, ref lockTaken);
                if (lockTaken)
                {
                    return _tasks;
                }
                else
                {
                    throw new NotSupportedException();
                }
            }
            finally
            {
                if (lockTaken) Monitor.Exit(_tasks);
            }
        }
    }
}
