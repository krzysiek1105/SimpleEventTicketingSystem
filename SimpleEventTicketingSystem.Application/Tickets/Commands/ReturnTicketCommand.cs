using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Tickets.Commands
{
    public class ReturnTicketCommand : IRequest
    {
        public Guid EventId { get; set; }
        public Guid Id { get; set; }
    }

    public class ReturnTicketCommandHandler : IRequestHandler<ReturnTicketCommand>
    {
        private readonly IEventsRepository _eventsRepository;

        public ReturnTicketCommandHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<Unit> Handle(ReturnTicketCommand request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.Get(request.EventId);

            @event.ReturnTicket(request.Id);

            _eventsRepository.Update(@event);
            await _eventsRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
