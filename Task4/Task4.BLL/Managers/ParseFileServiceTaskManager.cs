using System;
using System.Data.Entity;
using System.IO;
using System.Threading.Tasks;
using System.Transactions;
using Task4.BLL.Abstraction;
using Task4.BLL.CSVParsing;
using Task4.BLL.DataSourceProvider;
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
        private TaskFactory TaskFactory { get; set; }
        private TaskManager TaskManager { get; set; }
        public ParseFileServiceTaskManager()
        {
            TaskFactory = new TaskFactory();
            TaskManager = new TaskManager();
        }

        readonly Action<object> ParsingAction = (temp) =>
        {
            TempSourceFileDTO tempDTO = temp as TempSourceFileDTO;
            using (var DTOSource = new StringToDTOParser(tempDTO.FileName, tempDTO.DestFolder))
            {
                foreach (var item in DTOSource)
                {
                    TransactionScope scope = null;
                    DbContext context = null;
                    try
                    {
                        context = new FileDataModelContainer();
                        scope = new TransactionScope();

                        Client client = new Client()
                        {
                            Name = "Name"
                        };
                        IGenericRepository<Client> repository = new GenericRepository<Client>(context);
                        var operation = new AddEntityOperation<Client>(repository,scope);
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

        public void RunTask(object tempDTO)
        {
            ParsingAction(tempDTO);
            Task temp = null;
            try
            {
                TaskManager.TryAddTask(temp = TaskFactory.StartNew(ParsingAction, tempDTO,  TaskFactory.CancellationToken));
                temp.ContinueWith(x =>
                {
                    
                });
            }
            catch
            {
                throw new Exception("runTask");
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
