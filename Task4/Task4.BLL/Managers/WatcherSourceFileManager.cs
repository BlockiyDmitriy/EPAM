using System;
using System.IO;

namespace Task4.BLL.Managers
{
    public class WatcherSourceFileManager : BaseBackUpFileManager, IFileManager, IDisposable
    {
        protected FileSystemWatcher Watcher { get; set; }

        public WatcherSourceFileManager(FileSystemWatcher watcher, string destFolder) : base(watcher.Path, destFolder)
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
        public override void OnFileSystemEvent(object sender, FileSystemEventArgs e)
        {
            OnNew(this, e.FullPath);
        }
        ~WatcherSourceFileManager()
        {
            Dispose();
        }
    }
}
