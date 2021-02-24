using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Context;
using Task5.DAL.Repositories;
using Task5.DAL.Repositories.Contract;
using Task5.Domain;

namespace Task5.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private FileDataModelContainer context = new FileDataModelContainer();
        private Repository<Client> clientRepository;
        private Repository<Product> productRepository;
        private Repository<Order> orderRepository;
        public Repository<Client> ClientRepository
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new Repository<Client>(context);
                }
                return clientRepository;
            }
        }
        public Repository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new Repository<Product>(context);
                }
                return productRepository;
            }
        }
        public Repository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new Repository<Order>(context);
                }
                return orderRepository;
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
