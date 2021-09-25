using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Events.Commands
{
    public class CreateEventCommand : IRequest<Event>
    {
        public int TicketPoolCapacity { get; set; }
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Event>
    {
        private readonly IEventsRepository _eventsRepository;

        public CreateEventCommandHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = new Event(request.TicketPoolCapacity);
            _eventsRepository.Add(@event);
            await _eventsRepository.SaveChangesAsync();

            return @event;
        }
    }
}
