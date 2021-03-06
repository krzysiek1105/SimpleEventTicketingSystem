using SimpleEventTicketingSystem.Domain.Entities;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence
{
    public class TicketsRepository : CrudRepository<Ticket>, ITicketsRepository
    {
        public TicketsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
