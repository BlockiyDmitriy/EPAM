using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BLL.CSVParsing;
using Task4.BLL.Managers;

namespace Task4.BLL.DataSourceProvider
{
    public class SAXFileProvider : BaseFileProvider<CSVDTO>, IDataSourceProvider<CSVDTO>
    {
        bool _isCancelled = false;
        private TempSourceFileDTO _temp;
        public SAXFileProvider() : base()
        {
            _temp = new TempSourceFileDTO();
        }
        public SAXFileProvider(string sourceFolder, string destFolder)
            : base(sourceFolder, destFolder)
        {
        }
        public void Cancel()
        {
            _isCancelled = false;
        }
        public void Dispose()
        {
            // nothing to dispose
        }
        public void Start()
        {
            foreach (var file in
            Directory.GetFiles(
                SourceFolder,
                SearchPattern,
                SearchOption.TopDirectoryOnly))
            {
                _temp.FileName = file;
                _temp.DestFolder = DestFolder;
                var parse = new ParseFileServiceTaskManager();
                parse.RunTask(_temp);
                if (_isCancelled)
                {
                    break;
                }
            }
        }

        public void Stop()
        {
            Cancel();
        }
    }
}
