using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

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
        public Task<Unit> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
