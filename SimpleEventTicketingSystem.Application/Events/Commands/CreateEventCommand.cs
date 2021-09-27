using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Entities;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Events.Commands
{
    public class CreateEventResponse
    {
        public Guid Id { get; set; }
        public int TicketPoolCapacity { get; set; }
    }

    public class CreateEventCommand : IRequest<CreateEventResponse>
    {
        public int TicketPoolCapacity { get; set; }
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreateEventResponse>
    {
        private readonly IEventsRepository _eventsRepository;

        public CreateEventCommandHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<CreateEventResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var @event = new Event(request.TicketPoolCapacity);
            _eventsRepository.Add(@event);
            await _eventsRepository.SaveChangesAsync();

            return new CreateEventResponse
            {
                Id = @event.Id,
                TicketPoolCapacity = @event.TicketPoolPoolCapacity
            };
        }
    }
}
