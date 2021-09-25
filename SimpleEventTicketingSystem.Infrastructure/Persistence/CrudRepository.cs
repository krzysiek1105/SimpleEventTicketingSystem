using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleEventTicketingSystem.Domain;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence
{
    public abstract class CrudRepository<T> where T : Entity
    {
        protected readonly DatabaseContext DatabaseContext;

        protected CrudRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public virtual void Add(T entity)
        {
            DatabaseContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            DatabaseContext.Set<T>().Update(entity);
        }

        public virtual T Get(Guid id)
        {
            return DatabaseContext.Set<T>().Find(id) ?? throw new EntityDoesNotExistException($"{nameof(T)} with id {id} does not exist");
        }

        public virtual IList<T> Get()
        {
            return DatabaseContext.Set<T>().ToList();
        }

        public virtual void Remove(Guid id)
        {
            var set = DatabaseContext.Set<T>();
            var entity = set.Find(id);

            DatabaseContext.Set<T>().Remove(entity);
        }

        public virtual void Remove(T entity)
        {
            DatabaseContext.Set<T>().Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DatabaseContext.SaveChangesAsync();
        }
    }
}
