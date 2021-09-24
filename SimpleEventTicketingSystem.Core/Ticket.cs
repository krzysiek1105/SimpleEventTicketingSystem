using System;

namespace SimpleEventTicketingSystem.Domain
{
    public class Ticket : Entity
    {
        private readonly Guid _eventId;
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _email;

        protected Ticket()
        {
        }

        public Ticket(Guid eventId, string firstName, string lastName, string email)
        {
            _eventId = eventId;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }
    }
}
