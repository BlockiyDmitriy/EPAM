using Task4.Domain.Models;
using System.Data.Entity;

namespace Task4.DAL.Context
{
    public class FIleDataModelContainer : DbContext
    {
        public FIleDataModelContainer() : base("DbConnectionString")
        {
        } 
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Client> Client { get; set; }
    }
}
