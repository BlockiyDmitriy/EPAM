using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Repositories.Contract;
using Task5.Domain;

namespace Task5.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        internal DbContext Context { get; private set; }
        internal DbSet<Product> EntitySet { get; private set; }
        public ProductRepository(DbContext context)
        {
            this.Context = context;
            this.EntitySet = context.Set<Product>();
        }

        public IEnumerable<Product> Get()
        {
            if (EntitySet == null)
            {
                throw new ArgumentNullException("EntitySet");
            }
            return EntitySet.ToList();
        }

        public IEnumerable<Product> Get(Expression<Func<Product, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            return EntitySet.Where(predicate);
        }
        public Product SingleOrDefault(Expression<Func<Product, bool>> predicate)
        {
            return EntitySet.Where(predicate).SingleOrDefault();
        }
        public void Add(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            EntitySet.Add(entity);
        }

        public void Remove(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            EntitySet.Remove(entity);
        }
    }
}
