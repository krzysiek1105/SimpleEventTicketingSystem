﻿using SimpleEventTicketingSystem.Domain;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence
{
    public class EventsRepository : CrudRepository<Event>, IEventsRepository
    {
        public EventsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
