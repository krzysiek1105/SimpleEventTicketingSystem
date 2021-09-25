using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Events.Queries
{
    public class GetEventQuery : IRequest<Event>
    {
        public Guid Id { get; set; }
    }

    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, Event>
    {
        private readonly IEventsRepository _eventsRepository;

        public GetEventQueryHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public Task<Event> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_eventsRepository.Get(request.Id));
        }
    }
}