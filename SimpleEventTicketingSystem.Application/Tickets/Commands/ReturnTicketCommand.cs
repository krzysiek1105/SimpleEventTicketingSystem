using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SimpleEventTicketingSystem.Application.Tickets.Commands
{
    public class ReturnTicketCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class ReturnTicketCommandHandler : IRequestHandler<ReturnTicketCommand>
    {
        public Task<Unit> Handle(ReturnTicketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
