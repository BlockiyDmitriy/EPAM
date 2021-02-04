using System.Configuration;
using System.IO;
using Task4.BLL.DataSourceProvider;
using Task4.BLL.Managers;
using Task4.DAL.Context;
using Task4.Domain.Models;

namespace Task4.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new SAXFileProvider();
            provider.Start();
        }

    }
}
