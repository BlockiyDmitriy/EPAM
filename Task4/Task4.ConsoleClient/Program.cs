using System;
using System.Data.Entity;
using Task4.BLL.DataSourceProvider;

namespace Task4.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //DbContext db = new DbContext("DbConnectionString");
            //db.Database.Delete();
            //db.Database.Create();

            var provider = new SAXFileProvider();
            provider.Start();
        }

    }
}
