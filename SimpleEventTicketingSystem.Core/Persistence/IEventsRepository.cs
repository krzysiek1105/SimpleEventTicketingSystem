using System;
using System.Collections.Generic;

namespace SimpleEventTicketingSystem.Domain.Persistence
{
    public interface IEventsRepository
    {
        void Add(Event @event);
        Event Get(Guid id);
        IEnumerable<Event> Get();
        void Update(Event eEvent);
        void Delete(Event eEvent);
        void Delete(Guid eventId);
    }
}
