using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SimpleEventTicketingSystem.Application.Events.Queries
{
    public class GetEventQuery : IRequest
    {
        public Guid Id { get; set; }
    }

    public class GetEventQueryHandler : IRequestHandler<GetEventQuery>
    {
        public Task<Unit> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}