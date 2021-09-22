using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SimpleEventTicketingSystem.Application.Events.Commands
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        public Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
