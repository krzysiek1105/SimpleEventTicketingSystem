using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Events.Queries
{
    public class GetEventQuery : IRequest<EventDetailResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, EventDetailResponse>
    {
        private readonly IEventsRepository _eventsRepository;

        public GetEventQueryHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public Task<EventDetailResponse> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.Get(request.Id);

            return Task.FromResult(new EventDetailResponse
            {
                Id = @event.Id,
                TicketPoolCapacity = @event.TicketPoolPoolCapacity,
                TicketsAvailable = @event.TicketPoolPoolCapacity - @event.Tickets.Count
            });
        }
    }
}