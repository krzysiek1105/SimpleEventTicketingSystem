using SimpleEventTicketingSystem.Domain.Entities;

namespace SimpleEventTicketingSystem.Domain.Persistence
{
    public interface IEventsRepository : ICrudRepository<Event>
    {
    }
}
