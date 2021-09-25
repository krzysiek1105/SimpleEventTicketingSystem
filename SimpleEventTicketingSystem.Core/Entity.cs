using System;

namespace SimpleEventTicketingSystem.Domain
{
    public abstract class Entity
    {
        public virtual Guid Id { get; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
