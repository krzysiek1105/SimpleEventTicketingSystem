using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SimpleEventTicketingSystem.Domain
{
    public class Event
    {
        public Guid Id { get; }
        public int TicketPoolPoolCapacity { get; private set; }
        private readonly IList<Ticket> _tickets;
        public IReadOnlyCollection<Ticket> Tickets => new ReadOnlyCollection<Ticket>(_tickets);

        public Event(int ticketPoolCapacity)
        {
            if (ticketPoolCapacity <= 0)
            {
                throw new ArgumentException("Must be at least 1", nameof(ticketPoolCapacity));
            }

            Id = Guid.NewGuid();
            TicketPoolPoolCapacity = ticketPoolCapacity;
            _tickets = new List<Ticket>(TicketPoolPoolCapacity);
        }

        public void IncreaseTicketPoolCapacity(int incrementValue)
        {
            if (incrementValue <= 0)
            {
                throw new ArgumentException("Must be at least 1", nameof(incrementValue));
            }

            TicketPoolPoolCapacity += incrementValue;
        }

        public Ticket GetTicket(string firstName, string lastName, string email)
        {
            if (_tickets.Count >= TicketPoolPoolCapacity)
            {
                throw new InvalidOperationException("No tickets left for the event");
            }

            var ticket = new Ticket(Id, firstName, lastName, email);
            _tickets.Add(ticket);

            return ticket;
        }

        public void ReturnTicket(Ticket ticket)
        {
            if (!_tickets.Contains(ticket))
            {
                throw new InvalidOperationException("Ticket does not belong to the event");
            }

            _tickets.Remove(ticket);
        }
    }
}
