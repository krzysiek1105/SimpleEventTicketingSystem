using System;
using System.Collections.Generic;
using SimpleEventTicketingSystem.Domain;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence
{
    public class EventsRepository : IEventsRepository
    {
        public void Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public Event Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(Event eEvent)
        {
            throw new NotImplementedException();
        }

        public void Delete(Event eEvent)
        {
            throw new NotImplementedException();
        }
    }
}
