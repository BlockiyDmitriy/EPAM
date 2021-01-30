using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Task4.BLL.Scheduler;

namespace Task4.BLL.Managers
{
    public class TaskManager
    {
        private IProducerConsumerCollection<Task> Tasks { get; set; }
        private SafeStack<Task> Stack { get; set; }

        public TaskManager()
        {
            Stack = new SafeStack<Task>();
            Tasks = (IProducerConsumerCollection<Task>)Stack;
        }

        public void TryAddTask(Task task)
        {
            if (!Tasks.TryAdd(task))
            {
                throw new InvalidOperationException("connot to add task to thread-safe collection");
            }
        }
        public void TryTakeTask(Task task)
        {
            if (!Tasks.TryTake(out task))
            {
                throw new InvalidOperationException("connot to take task to thread-safe collection");
            }
        }
    }
}
