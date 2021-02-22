using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task5.DAL.Context;
using Task5.DAL.Repositories.Contract;
using Task5.Domain;

namespace Task5.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        internal DbContext Context { get; private set; }
        internal DbSet<Order> EntitySet { get; private set; }
        public OrderRepository(DbContext context)
        {
            this.Context = context;
            this.EntitySet = context.Set<Order>();
        }

        public IEnumerable<Order> Get()
        {
            if (EntitySet == null)
            {
                throw new ArgumentNullException("EntitySet");
            }
            return EntitySet.ToList();
        }

        public IEnumerable<Order> Get(Expression<Func<Order, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            return EntitySet.Where(predicate);
        }
        public Order SingleOrDefault(Expression<Func<Order, bool>> predicate)
        {
            return EntitySet.Where(predicate).SingleOrDefault();
        }
        public void Add(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            EntitySet.Add(entity);
        }

        public void Remove(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            EntitySet.Remove(entity);
        }
    }
}
