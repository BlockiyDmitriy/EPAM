using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BLL.Abstraction;
using Task4.BLL.DataSourceProvider;

namespace Task4.BLL.Managers
{
    public interface IFileManager : IControlProcess, IBackupable
    {
        string SourceFile { get; }
        string DestFolder { get; }

        event EventHandler<string> New;
    }
}
