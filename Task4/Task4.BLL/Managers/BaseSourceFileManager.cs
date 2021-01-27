using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BLL.Managers
{
    public abstract class BaseSourceFileManager
    {
        public string SourceFolder { get; private set; }
        public string DestFolder { get; private set; }

        protected BaseSourceFileManager(string sourceFolder, string destFolder)
        {
            SourceFolder = sourceFolder;
            DestFolder = destFolder;
        }

        protected void BackUpSourceFile(string fileName)
        {
            string destFileName = string.Empty;
            File.Move(fileName, destFileName);
        }
        public void BackUp(string fileName)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                File.Move(fileName, $"{DestFolder},{fileInfo.Name}");
            }
            catch (IOException e)
            {
                throw new InvalidOperationException("cannot backup file", e);
            }
        }
        public event EventHandler<string> New;

        protected virtual void OnNew(object sender, string fileName)
        {
            New?.Invoke(this, fileName);
        }

        public abstract void OnFileSystemEvent(object sender, FileSystemEventArgs e);
    }
}
