using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Context;
using Task5.DAL.Repositories;

namespace Task5.DAL.UoW
{
    public class UnitOfWork<TEntity> : IUnitOfWork where TEntity : class
    {
        private FileDataModelContainer context = new FileDataModelContainer();
        private Repository<TEntity> repository;

        public Repository<TEntity> Repository
        {
            get
            {
                if (repository == null)
                {
                    repository = new Repository<TEntity>(context);
                }
                return repository;
            }
        }
        public void Save()
        {
            context?.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
