using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SimpleEventTicketingSystem.Application.Events.Commands
{
    public class CreateEventCommand : IRequest
    {
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand>
    {
        public Task<Unit> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
