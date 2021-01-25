using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Domain.Models;

namespace Task4.DAL.Context
{
    public class FIleDataModelContainer : DbContext
    {
        public FIleDataModelContainer() : base("DbConnectionString")
        {
        }
        internal DbSet<File> Files { get; private set; }
        internal DbSet<StructFile> StructFiles { get; private set; }
    }
}
