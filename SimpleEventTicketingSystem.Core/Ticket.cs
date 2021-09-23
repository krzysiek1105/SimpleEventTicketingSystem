using System;

namespace SimpleEventTicketingSystem.Domain
{
    public class Ticket
    {
        private readonly Guid _id;
        private readonly Guid _eventId;
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _email;

        public Ticket(Guid eventId, string firstName, string lastName, string email)
        {
            _id = Guid.NewGuid();
            _eventId = eventId;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }
    }
}
