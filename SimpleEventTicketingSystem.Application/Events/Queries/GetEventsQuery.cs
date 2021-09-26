using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Events.Queries
{
    public class GetEventsQuery : IRequest<IEnumerable<EventDetailResponse>>
    {
    }

    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IEnumerable<EventDetailResponse>>
    {
        private readonly IEventsRepository _eventsRepository;

        public GetEventsQueryHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public Task<IEnumerable<EventDetailResponse>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_eventsRepository.Get().Select(e => new EventDetailResponse
            {
                Id = e.Id,
                TicketPoolCapacity = e.TicketPoolPoolCapacity,
                TicketsAvailable = e.TicketPoolPoolCapacity - e.Tickets.Count
            }));
        }
    }
}
