using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Tickets.Queries
{
    public class TicketAvailabilityForEventResponse
    {
        public Guid EventId { get; set; }
        public int TicketsAvailable { get; set; }
    }

    public class GetTicketAvailabilityForEventQuery : IRequest<TicketAvailabilityForEventResponse>
    {
        public Guid EventId { get; set; }
    }

    public class GetTicketAvailabilityForEventQueryHandler : IRequestHandler<GetTicketAvailabilityForEventQuery, TicketAvailabilityForEventResponse>
    {
        private readonly IEventsRepository _eventsRepository;

        public GetTicketAvailabilityForEventQueryHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public Task<TicketAvailabilityForEventResponse> Handle(GetTicketAvailabilityForEventQuery request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.Get(request.EventId);

            return Task.FromResult(new TicketAvailabilityForEventResponse
            {
                EventId = @event.Id,
                TicketsAvailable = @event.TicketPoolPoolCapacity - @event.Tickets.Count
            });
        }
    }
}
