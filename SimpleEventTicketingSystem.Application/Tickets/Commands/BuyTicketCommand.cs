using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Tickets.Commands
{
    public class BuyTicketResponse
    {
        public Guid EventId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class BuyTicketCommand : IRequest<BuyTicketResponse>
    {
        public Guid EventId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class BuyTicketCommandHandler : IRequestHandler<BuyTicketCommand, BuyTicketResponse>
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly ITicketsRepository _ticketsRepository;

        public BuyTicketCommandHandler(IEventsRepository eventsRepository, ITicketsRepository ticketsRepository)
        {
            _eventsRepository = eventsRepository;
            _ticketsRepository = ticketsRepository;
        }

        public async Task<BuyTicketResponse> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.Get(request.EventId);
            var ticket = @event.GetTicket(request.FirstName, request.LastName, request.Email);

            _ticketsRepository.Add(ticket);
            await _eventsRepository.SaveChangesAsync();

            return new BuyTicketResponse
            {
                Email = ticket.Email,
                EventId = @event.Id,
                FirstName = ticket.FirstName,
                LastName = ticket.LastName
            };
        }
    }
}
