using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Context;
using Task5.DAL.Repositories;

namespace Task5.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private FileDataModelContainer context = new FileDataModelContainer();
        private ClientRepository clientRepository;
        private ProductRepository productRepository;
        private OrderRepository orderRepository;
        public ClientRepository ClientRepository
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new ClientRepository(context);
                }
                return clientRepository;
            }
        }
        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(context);
                }
                return productRepository;
            }
        }
        public OrderRepository OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new OrderRepository(context);
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
