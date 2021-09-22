using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SimpleEventTicketingSystem.Application.Events.Commands
{
    public class IncrementTicketPoolCommand : IRequest
    {
        public Guid EventId { get; set; }
        public int IncrementValue { get; set; }
    }

    public class IncrementTicketPoolCommandHandler : IRequestHandler<IncrementTicketPoolCommand>
    {
        public Task<Unit> Handle(IncrementTicketPoolCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
