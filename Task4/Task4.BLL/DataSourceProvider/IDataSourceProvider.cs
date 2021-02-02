using System;
using Task4.BLL.Abstraction;

namespace Task4.BLL.DataSourceProvider
{
    public interface IDataSourceProvider<T> : IControlProcess, IDisposable
    {
        event EventHandler<IDataSource<T>> New;
    }
}
