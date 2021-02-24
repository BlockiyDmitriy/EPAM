using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Repositories;
using Task5.Domain;

namespace Task5.DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
