using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5.DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
