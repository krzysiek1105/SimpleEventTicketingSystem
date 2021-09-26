using System;

namespace SimpleEventTicketingSystem.Application.Events.Queries
{
    public class EventDetailResponse
    {
        public Guid Id { get; set; }
        public int TicketPoolCapacity { get; set; }
        public int TicketsAvailable { get; set; }
    }
}