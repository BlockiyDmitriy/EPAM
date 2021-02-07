using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Task4.BLL.DataSourceProvider;
using Task4.BLL.Managers;

namespace Task4.ServiceClient
{
    public partial class Service1 : ServiceBase
    {
        WatcherSourceFileManager watcher;
        SAXFileProvider provider;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                watcher = new WatcherSourceFileManager(new FileSystemWatcher());
                watcher.Start();
                provider = new SAXFileProvider();
                provider.Start();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        protected override void OnStop()
        {
            try
            {
                watcher.Stop();
                provider.Stop();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
