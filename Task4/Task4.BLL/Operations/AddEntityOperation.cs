using Task4.BLL.Abstraction;
using Task4.DAL.Repositories.Contracts;
using Task4.Domain.Models;

using System;
using System.Transactions;

namespace Task4.BLL.Operations
{
    public class AddEntityOperation<TEntity> : IUnitOfWork where TEntity : class
    {
        public TEntity Entity { get; private set; }
        protected IGenericRepository<TEntity> ClientRepo { get; private set; }
        protected TransactionScope Scope { get; private set; }

        public AddEntityOperation(IGenericRepository<TEntity> clientRepo, TransactionScope scope)
        {
            ClientRepo = clientRepo;
            Scope = scope;
        }

        public void Commit()
        {
            Scope.Complete();
        }

        public void Rollback()
        {
            throw new Exception();
        }

        public void Execute()
        {
            try
            {
                ClientRepo.Add(Entity);
                Scope.Complete();
            }
            catch (NullReferenceException e)
            {
                Rollback();
                throw e;
            }
            catch (TransactionException e)
            {
                Rollback();
                throw new InvalidOperationException("Add entity faild ", e);
            }
        }

        public void Dispose()
        {
            Scope.Dispose();
        }
    }
}
