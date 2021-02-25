using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Entities;
using Task5.DAL.Repositories;

namespace Task5.DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Client> ClientRepository { get; }
        Repository<Product> ProductRepository { get; }
        Repository<Order> OrderRepository { get; }
        void Save();
    }
}
