using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SimpleEventTicketingSystem.Domain.Exceptions;
using SimpleEventTicketingSystem.Domain.ValueObjects;

namespace SimpleEventTicketingSystem.Domain.Entities
{
    public class Event : Entity
    {
        public int TicketPoolPoolCapacity { get; protected set; }
        private List<Ticket> _tickets;
        public virtual IReadOnlyCollection<Ticket> Tickets => new ReadOnlyCollection<Ticket>(_tickets);

        protected Event()
        {
            _tickets = new List<Ticket>();
        }

        public Event(int ticketPoolCapacity)
        {
            if (ticketPoolCapacity <= 0)
            {
                throw new EventDomainException("Ticket pool must be at least 1");
            }

            TicketPoolPoolCapacity = ticketPoolCapacity;
            _tickets = new List<Ticket>(TicketPoolPoolCapacity);
        }

        public void IncreaseTicketPoolCapacity(int incrementValue)
        {
            if (incrementValue <= 0)
            {
                throw new EventDomainException("Ticket pool increment value must be at least 1");
            }

            TicketPoolPoolCapacity += incrementValue;
        }

        public Ticket GetTicket(FirstName firstName, LastName lastName, Email email)
        {
            if (Tickets.Count >= TicketPoolPoolCapacity)
            {
                throw new EventDomainException("No tickets left for the event");
            }

            var ticket = new Ticket(this, firstName, lastName, email);
            _tickets.Add(ticket);

            return ticket;
        }

        public void ReturnTicket(Ticket ticket)
        {
            if (!Tickets.Contains(ticket))
            {
                throw new EventDomainException("Ticket does not belong to the event");
            }

            _tickets.Remove(ticket);
        }
    }
}
