using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;
using SimpleEventTicketingSystem.Domain.ValueObjects;

namespace SimpleEventTicketingSystem.Application.Tickets.Commands
{
    public class BuyTicketResponse
    {
        public Guid EventId { get; set; }
        public Guid TicketId { get; set; }
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

            var firstName = new FirstName(request.FirstName);
            var lastName = new LastName(request.LastName);
            var email = new Email(request.Email);

            var ticket = @event.GetTicket(firstName, lastName, email);

            _ticketsRepository.Add(ticket);
            await _eventsRepository.SaveChangesAsync();

            return new BuyTicketResponse
            {
                Email = ticket.Email.Value,
                EventId = @event.Id,
                TicketId = ticket.Id,
                FirstName = ticket.FirstName.Value,
                LastName = ticket.LastName.Value
            };
        }
    }
}
