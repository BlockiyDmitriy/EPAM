using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BLL.DataSourceProvider
{
    public interface IDataSource<T> : IEnumerable<T>, IDisposable
    {
        void Close();
    }
}
