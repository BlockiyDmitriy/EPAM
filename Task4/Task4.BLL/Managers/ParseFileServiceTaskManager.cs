using System;
using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using System.Transactions;
using Task4.BLL.Abstraction;
using Task4.BLL.CSVParsing;
using Task4.BLL.Scheduler;
using Task4.DAL.Context;

namespace Task4.BLL.Managers
{
    public class ParseFileServiceTaskManager : IControlProcess
    {
        private IFileManager FileManager { get; set; }
        private TaskFactory TaskFactory { get; set; }
        private TaskManager TaskManager { get; set; }
        private SafeStack<Task> Stack { get; set; }

        public ParseFileServiceTaskManager()
        {
            TaskFactory = new TaskFactory();
            TaskManager = new TaskManager();
            Stack = new SafeStack<Task>();
        }

        Action<object> ParsingAction = param =>
        {
            string fileName = param as string;

            using (var DTOSource = new StringToDTOParser(new StreamReader(fileName)))
            {
                foreach (var item in DTOSource)
                {
                    TransactionScope scope = null;
                    DbContext context = null;
                    try
                    {
                        context = new FileDataModelContainer();
                        //scope = 
                    }
                    finally
                    {
                        scope.Dispose();
                        context.Dispose();
                        GC.SuppressFinalize(scope);
                        GC.SuppressFinalize(context);
                    }
                }
            }
        };

        public void RunTask(string fileName)
        {
            Task temp = null;
            try
            {
                Stack.TryAdd(temp); // Test
                TaskManager.TryTakeTask(temp = TaskFactory.StartNew(ParsingAction, fileName, TaskFactory.CancellationToken));
                temp.ContinueWith(x =>
                {
                    FileManager.BackUp(fileName);

                });
            }
            catch
            {

            }
        }
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
