using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleEventTicketingSystem.Domain.Persistence
{
    public interface ICrudRepository<T> where T : Entity
    {
        void Add(T entity);
        T Get(Guid id);
        IList<T> Get();
        void Update(T entity);
        void Remove(T entity);
        void Remove(Guid id);
        Task<int> SaveChangesAsync();
    }
}
