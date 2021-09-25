using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Tickets.Commands
{
    public class BuyTicketCommand : IRequest
    {
        public Guid EventId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class BuyTicketCommandHandler : IRequestHandler<BuyTicketCommand>
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly ITicketsRepository _ticketsRepository;

        public BuyTicketCommandHandler(IEventsRepository eventsRepository, ITicketsRepository ticketsRepository)
        {
            _eventsRepository = eventsRepository;
            _ticketsRepository = ticketsRepository;
        }

        public async Task<Unit> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.Get(request.EventId);
            var ticket = @event.GetTicket(request.FirstName, request.LastName, request.Email);

            _ticketsRepository.Add(ticket);

            await _eventsRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
