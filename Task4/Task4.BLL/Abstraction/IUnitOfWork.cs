using System;

namespace Task4.BLL.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        void Execute();
    }
}
