using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BLL.Abstraction;
using Task4.BLL.DataSourceProvider;

namespace Task4.BLL.Managers
{
    public interface IFileManager<TDataItem> : IControlProcess
    {
        string SourceFolder { get; }
        string DestFolder { get; }
        string SearchPattern { get; }

        event EventHandler<IDataSource<TDataItem>> New;
    }
}
