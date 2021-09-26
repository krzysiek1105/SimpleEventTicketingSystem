using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Events.Commands
{
    public class IncrementTicketPoolResponse
    {
        public Guid EventId { get; set; }
        public int OldTicketPoolCapacity { get; set; }
        public int NewTicketPoolCapacity { get; set; }
    }

    public class IncrementTicketPoolCommand : IRequest<IncrementTicketPoolResponse>
    {
        public Guid EventId { get; set; }
        public int IncrementValue { get; set; }
    }

    public class IncrementTicketPoolCommandHandler : IRequestHandler<IncrementTicketPoolCommand, IncrementTicketPoolResponse>
    {
        private readonly IEventsRepository _eventsRepository;

        public IncrementTicketPoolCommandHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<IncrementTicketPoolResponse> Handle(IncrementTicketPoolCommand request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.Get(request.EventId);

            var incrementTicketPoolResponse = new IncrementTicketPoolResponse
            {
                EventId = @event.Id,
                OldTicketPoolCapacity = @event.TicketPoolPoolCapacity
            };

            @event.IncreaseTicketPoolCapacity(request.IncrementValue);

            incrementTicketPoolResponse.NewTicketPoolCapacity = @event.TicketPoolPoolCapacity;

            _eventsRepository.Update(@event);
            await _eventsRepository.SaveChangesAsync();

            return incrementTicketPoolResponse;
        }
    }
}
