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
        protected UnitOfWork UOW { get; set; }

        private bool disposed = false;
        protected AbstructService(UnitOfWork uOW) : this()
        {
            this.UOW = uOW;
        }
        protected AbstructService()
        {
            if(UOW == null)
            {
                UOW = new UnitOfWork();
            }
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
