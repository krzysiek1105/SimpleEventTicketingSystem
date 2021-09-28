using System;
using System.Linq;
using SimpleEventTicketingSystem.Domain.Entities;
using SimpleEventTicketingSystem.Domain.Exceptions;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence
{
    public class EventsRepository : CrudRepository<Event>, IEventsRepository
    {
        public EventsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override Event Get(Guid id)
        {
            return DatabaseContext.Set<Event>().SingleOrDefault(e => e.Id == id) ?? throw new EntityDoesNotExistException($"{nameof(Event)} with id {id} does not exist");
        }
    }
}
