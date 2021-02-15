using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Repositories.Contract;

namespace Task5.DAL.Repositories
{
    class Repository<TEntity>:IRepository<TEntity> where TEntity: class
    {
        internal DbContext Context { get; private set; }
        internal DbSet<TEntity> EntitySet { get; private set; }
        public Repository(DbContext context)
        {
            this.Context = context;
            this.EntitySet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            if (EntitySet == null)
            {
                throw new ArgumentNullException("EntitySet");
            }
            return EntitySet;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            return EntitySet.Where(predicate);
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return EntitySet.Where(predicate).SingleOrDefault();
        }
    }
}
