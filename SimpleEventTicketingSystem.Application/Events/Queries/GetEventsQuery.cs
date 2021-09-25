using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Events.Queries
{
    public class GetEventsQuery : IRequest<IList<Event>>
    {
    }

    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, IList<Event>>
    {
        private readonly IEventsRepository _eventsRepository;

        public GetEventsQueryHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public Task<IList<Event>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_eventsRepository.Get());
        }
    }
}
