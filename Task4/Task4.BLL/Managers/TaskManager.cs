using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Task4.BLL.Managers
{
    public class TaskManager
    {
        public IProducerConsumerCollection<Task> Tasks { get; private set; }

        public TaskManager(IProducerConsumerCollection<Task> source)
        {
            Tasks = source;
        }

        public void TryAddTask(Task task)
        {
            if (!Tasks.TryAdd(task))
            {
                throw new InvalidOperationException("connot to add task to thread-safe collection");
            }
        }
        public void TryTakeTask(Task task )
        {
            if (!Tasks.TryTake(out task))
            {
                throw new InvalidOperationException("connot to take task to thread-safe collection");
            }
        }
    }
}
