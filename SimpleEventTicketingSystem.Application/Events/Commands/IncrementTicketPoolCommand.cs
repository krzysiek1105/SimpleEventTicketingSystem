using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Events.Commands
{
    public class IncrementTicketPoolCommand : IRequest
    {
        public Guid EventId { get; set; }
        public int IncrementValue { get; set; }
    }

    public class IncrementTicketPoolCommandHandler : IRequestHandler<IncrementTicketPoolCommand>
    {
        private readonly IEventsRepository _eventsRepository;

        public IncrementTicketPoolCommandHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public Task<Unit> Handle(IncrementTicketPoolCommand request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.Get(request.EventId);
            @event.IncreaseTicketPoolCapacity(request.IncrementValue);
            _eventsRepository.Update(@event);

            return Unit.Task;
        }
    }
}
