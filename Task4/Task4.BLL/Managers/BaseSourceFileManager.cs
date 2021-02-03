using System;
using System.IO;

namespace Task4.BLL.Managers
{
    public abstract class BaseSourceFileManager
    {
        public event EventHandler<string> New;

        protected virtual void OnNew(object sender, string fileName)
        {
            New?.Invoke(this, fileName);
        }

        public abstract void OnFileSystemEvent(object sender, FileSystemEventArgs e);
    }
}
