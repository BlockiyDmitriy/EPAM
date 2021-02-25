using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task5.BLL.Extentions;
using Task5.DAL.Repositories;
using Task5.DAL.UoW;

namespace Task5.BLL.Services.Abstruct
{
    public abstract class AbstructService
    {
        protected IUnitOfWork UOW { get; set; }

        private bool disposed = false;
        protected AbstructService(IUnitOfWork uOW)
        {
            this.UOW = uOW;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    UOW.Dispose();
                }
            }
            disposed = true;
        }

    }
}
