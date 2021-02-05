using System;
using System.Data.Entity;
using System.Transactions;
using Task4.BLL.Abstraction;
using Task4.BLL.Operations;
using Task4.DAL.Context;
using Task4.DAL.Repositories;
using Task4.DAL.Repositories.Contracts;
using Task4.Domain.Models;

namespace Task4.BLL.Transaction
{
    public class TransactDataTask : IDisposable
    {
        protected DbContext Context { get; set; }

        public TransactDataTask(FileDataModelContainer context)
        {
            Context = context;
        }

        public void TransactStartTask()
        {
            try
            {
                Context.Database.Connection.Open();
                IGenericRepository<Client> clientRepository = new GenericRepository<Client>(Context);

                using (var Scope = new TransactionScope())
                {
                    IUnitOfWork addEntity = new AddEntityOperation<Client>(clientRepository, Scope)
                    {
                        Entity = new Client()
                        {
                            Name = "Name"
                        }                        
                    };
                    addEntity.Execute();
                }
                Context.Database.Connection.Close();
            }

            catch (Exception e)
            {
                throw new InvalidOperationException("Task failed", e);
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(Context);
        }
    }
}
