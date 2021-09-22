using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SimpleEventTicketingSystem.Application.Events.Queries
{
    public class GetEventsQuery : IRequest
    {
    }

    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery>
    {
        public Task<Unit> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
