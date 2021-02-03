using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BLL.DataSourceProvider;

namespace Task4.BLL.Managers
{
    public abstract class BaseBackUpFileManager : BaseSourceFileManager, IBackupable
    {
        public string SourceFile { get; private set; }
        public string DestFolder { get; private set; }

        protected BaseBackUpFileManager(string sourceFile, string destFolder)
        {
            SourceFile = sourceFile;
            DestFolder = destFolder;
        }
        public virtual void BackUp()
        {
            try
            {
                FileInfo fileInfo = new FileInfo(SourceFile);
                File.Move(SourceFile, $"{DestFolder},{fileInfo.Name}");
            }
            catch (IOException e)
            {
                throw new InvalidOperationException("cannot backup file", e);
            }
        }
    }
}
