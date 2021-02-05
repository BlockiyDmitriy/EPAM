using System;
using System.IO;
using Task4.BLL.CSVParsing;
using Task4.BLL.DataSourceProvider;

namespace Task4.BLL.Managers
{
    public class WatcherSourceFileManager : BaseFileProvider<CSVDTO>, IFileManager<CSVDTO>, IDisposable
    {
        protected FileSystemWatcher Watcher { get; set; }

        public WatcherSourceFileManager(FileSystemWatcher watcher) : base()
        {
            Watcher = watcher;
            Watcher.Created += OnFileSystemEvent;
        }
        public void Start()
        {
            if (Watcher != null)
            {
                Watcher.EnableRaisingEvents = true;
            }
        }
        public void Stop()
        {
            if (Watcher != null)
            {
                Watcher.EnableRaisingEvents = false;
            }
        }
        public void Dispose()
        {
            if (Watcher != null)
            {
                Watcher.Dispose();
                GC.SuppressFinalize(this);
                Watcher = null;
            }
        }
        protected void OnFileSystemEvent(object sender, FileSystemEventArgs e)
        {
            OnNew(this, new StringToDTOParser(e.FullPath, this.DestFolder));
        }
        ~WatcherSourceFileManager()
        {
            Dispose();
        }
    }
}
