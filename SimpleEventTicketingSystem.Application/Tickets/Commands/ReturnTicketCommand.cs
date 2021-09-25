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
        private readonly ITicketsRepository _ticketsRepository;

        public ReturnTicketCommandHandler(IEventsRepository eventsRepository, ITicketsRepository ticketsRepository)
        {
            _eventsRepository = eventsRepository;
            _ticketsRepository = ticketsRepository;
        }

        public async Task<Unit> Handle(ReturnTicketCommand request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.Get(request.EventId);
            var ticket = _ticketsRepository.Get(request.Id);

            @event.ReturnTicket(ticket);

            _ticketsRepository.Remove(ticket);
            _eventsRepository.Update(@event);

            await _eventsRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
