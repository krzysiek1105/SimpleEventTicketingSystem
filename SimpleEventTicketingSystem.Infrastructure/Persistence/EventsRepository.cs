using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SimpleEventTicketingSystem.Domain;
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
            return DatabaseContext.Set<Event>().Include(e => e.Tickets).Single(e => e.Id == id);
        }
    }
}
