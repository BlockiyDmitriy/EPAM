using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.DAL.Context
{
    class FileDataModelContainer : DbContext
    {
        public FileDataModelContainer(): base("DbConnectionString")
        {

        }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Client> Client { get; set; }
    }
}
