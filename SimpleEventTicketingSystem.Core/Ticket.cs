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
            Event = @event;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
