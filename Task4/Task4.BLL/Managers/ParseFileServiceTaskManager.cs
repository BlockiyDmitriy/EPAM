using System;
using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using System.Transactions;
using Task4.BLL.Abstraction;
using Task4.BLL.CSVParsing;
using Task4.BLL.Operations;
using Task4.BLL.Scheduler;
using Task4.DAL.Context;
using Task4.DAL.Repositories;
using Task4.DAL.Repositories.Contracts;
using Task4.Domain.Models;

namespace Task4.BLL.Managers
{
    public class ParseFileServiceTaskManager : IControlProcess
    {
        private IFileManager FileManager { get; set; }
        private TaskFactory TaskFactory { get; set; }
        private TaskManager TaskManager { get; set; }
        public ParseFileServiceTaskManager()
        {
            TaskFactory = new TaskFactory();
            TaskManager = new TaskManager();
        }

        Action<object> ParsingAction = (param) =>
        {
            Console.WriteLine("Parsing");
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
                        scope = new TransactionScope();

                        //Client client = new Client() { Name = "client" };
                        //IGenericRepository<Client> genericRepository = new GenericRepository<Client>(context);
                        //AddEntityOperation<Client> addEntity = new AddEntityOperation<Client>(genericRepository, scope);
                        //addEntity.Execute(client);
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

        public void RunTask(object fileName)
        {
            ParsingAction(fileName);
            Task temp = null;
            string file = fileName as string;
            try
            {
                TaskManager.TryAddTask(temp = TaskFactory.StartNew(ParsingAction, file, TaskFactory.CancellationToken));
                temp.ContinueWith(x =>
                {
                    FileManager.BackUp(file);

                });
            }
            catch
            {
                throw new Exception();
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
