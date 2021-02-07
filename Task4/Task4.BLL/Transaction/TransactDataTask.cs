using System;
using System.Data.Entity;
using System.Transactions;
using Task4.BLL.Abstraction;
using Task4.BLL.CSVParsing;
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

        public void TransactStartTask(CSVDTO cSVDTO)
        {
            try
            {
                Context.Database.Connection.Open();
                IGenericRepository<Client> clientRepository = new GenericRepository<Client>(Context);
                IGenericRepository<Product> productRepository = new GenericRepository<Product>(Context);
                IGenericRepository<Order> orderRepository = new GenericRepository<Order>(Context);
                using (var Scope = new TransactionScope())
                {
                    IUnitOfWork addClient = new AddEntityOperation<Client>(clientRepository, Scope)
                    {
                        Entity = new Client()
                        {
                            Name = cSVDTO.ClientName
                        }
                    };
                    addClient.Execute();
                }
                using (var Scope = new TransactionScope())
                {
                    IUnitOfWork addProduct = new AddEntityOperation<Product>(productRepository, Scope)
                    {
                        Entity = new Product()
                        {
                            Name = cSVDTO.Product,
                            Sum = cSVDTO.Sum
                        }
                    };
                    addProduct.Execute();
                }
                var client = clientRepository.SingleOrDefault(x => x.Name == cSVDTO.ClientName);
                var product = productRepository.SingleOrDefault(x => x.Name == cSVDTO.Product);
                var order = new Order()
                {
                    DateTime = cSVDTO.DateTime,
                    Client = client,
                    Product = product
                };
                orderRepository.Add(order);
                //orderRepository.Save();
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
