namespace SimpleEventTicketingSystem.Domain
{
    public class Ticket : Entity
    {
        public Event Event { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }

        protected Ticket()
        {
        }

        public Ticket(Event @event, string firstName, string lastName, string email)
        {
            Event = @event ?? throw new TicketDomainException("Event cannot be null");
            FirstName = firstName ?? throw new TicketDomainException("First name cannot be null");
            LastName = lastName ?? throw new TicketDomainException("Last name cannot be null");
            Email = email ?? throw new TicketDomainException("Email cannot be null");
        }
    }
}
