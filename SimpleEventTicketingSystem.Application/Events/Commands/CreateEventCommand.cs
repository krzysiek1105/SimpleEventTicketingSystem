using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Events.Commands
{
    public class CreateEventCommand : IRequest
    {
        public int TicketPoolCapacity { get; set; }
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        private readonly IEventsRepository _eventsRepository;

        public CreateEventCommandHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public Task<Unit> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = new Event(request.TicketPoolCapacity);
            _eventsRepository.Add(@event);

            return Unit.Task;
        }
    }
}
