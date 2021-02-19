using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Domain;

namespace Task5.DAL.Context
{
    public class FileDataModelContainer : DbContext
    {
        public FileDataModelContainer() : base("DbConnectionString")
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
