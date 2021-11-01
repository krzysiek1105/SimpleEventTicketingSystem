using SimpleEventTicketingSystem.Domain.Entities;

namespace SimpleEventTicketingSystem.Domain.Persistence
{
    public interface ITicketsRepository : ICrudRepository<Ticket>
    {
    }
}