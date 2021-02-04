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
        protected TransactionScope Scope { get; set; }

        public TransactDataTask(FileDataModelContainer context, TransactionScope scope)
        {
            Context = context;
            Scope = scope;
        }

        public void TransactCompliteTask()
        {
            try
            {
                Context.Database.Connection.Open();
                IGenericRepository<Client> clientRepository = new GenericRepository<Client>(Context);

                using (Scope = new TransactionScope())
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
            Scope.Dispose();
            GC.SuppressFinalize(Context);
            GC.SuppressFinalize(Scope);
        }
    }
}
