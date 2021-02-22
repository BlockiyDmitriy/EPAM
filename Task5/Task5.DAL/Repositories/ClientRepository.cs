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
    public class ClientRepository : IRepository<Client>
    {
        internal DbContext Context { get; private set; }
        internal DbSet<Client> EntitySet { get; private set; }
        public ClientRepository(DbContext context)
        {
            this.Context = context;
            this.EntitySet = context.Set<Client>();
        }

        public IEnumerable<Client> Get()
        {
            if (EntitySet == null)
            {
                throw new ArgumentNullException("EntitySet");
            }
            return EntitySet.ToList();
        }

        public IEnumerable<Client> Get(Expression<Func<Client, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }
            return EntitySet.Where(predicate);
        }
        public Client SingleOrDefault(Expression<Func<Client, bool>> predicate)
        {
            return EntitySet.Where(predicate).SingleOrDefault();
        }
        public void Add(Client entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            EntitySet.Add(entity);
        }

        public void Remove(Client entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            EntitySet.Remove(entity);
        }
    }
}
