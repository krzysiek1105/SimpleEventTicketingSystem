using SimpleEventTicketingSystem.Domain.Exceptions;
using SimpleEventTicketingSystem.Domain.ValueObjects;

namespace SimpleEventTicketingSystem.Domain.Entities
{
    public class Ticket : Entity
    {
        public Event Event { get; protected set; }
        public FirstName FirstName { get; protected set; }
        public LastName LastName { get; protected set; }
        public Email Email { get; protected set; }

        protected Ticket()
        {
        }

        public Ticket(Event @event, FirstName firstName, LastName lastName, Email email)
        {
            Event = @event ?? throw new TicketDomainException("Event cannot be null");
            FirstName = firstName ?? throw new TicketDomainException("First name cannot be null");
            LastName = lastName ?? throw new TicketDomainException("Last name cannot be null");
            Email = email ?? throw new TicketDomainException("Email cannot be null");
        }
    }
}
