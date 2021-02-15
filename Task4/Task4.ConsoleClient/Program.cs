using System;
using System.Data.Entity;
using System.IO;
using Task4.BLL.DataSourceProvider;
using Task4.BLL.Managers;

namespace Task4.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext db = new DbContext("DbConnectionString");
            db.Database.Delete();
            db.Database.Create();

            var watcher = new WatcherSourceFileManager(new FileSystemWatcher());
            watcher.Start();
            var provider = new SAXFileProvider();
            provider.Start();
        }

    }
}
