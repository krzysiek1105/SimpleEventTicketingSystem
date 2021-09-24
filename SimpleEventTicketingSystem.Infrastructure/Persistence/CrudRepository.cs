using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleEventTicketingSystem.Domain;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence
{
    public abstract class CrudRepository<T> where T : Entity
    {
        private readonly DatabaseContext _databaseContext;

        protected CrudRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(T entity)
        {
            _databaseContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _databaseContext.Set<T>().Update(entity);
        }

        public T Get(Guid id)
        {
            return _databaseContext.Set<T>().Find(id);
        }

        public IList<T> Get()
        {
            return _databaseContext.Set<T>().ToList();
        }

        public void Remove(Guid id)
        {
            var set = _databaseContext.Set<T>();
            var entity = set.Find(id);

            _databaseContext.Set<T>().Remove(entity);
        }

        public void Remove(T entity)
        {
            _databaseContext.Set<T>().Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _databaseContext.SaveChangesAsync();
        }
    }
}
