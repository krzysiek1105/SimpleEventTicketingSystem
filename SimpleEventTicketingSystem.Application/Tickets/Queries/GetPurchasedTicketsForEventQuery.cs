using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SimpleEventTicketingSystem.Application.Tickets.Queries
{
    public class GetPurchasedTicketsForEventQuery : IRequest
    {
        public Guid EventId { get; set; }
    }

    public class GetPurchasedTicketsForEventQueryHandler : IRequestHandler<GetPurchasedTicketsForEventQuery>
    {
        public Task<Unit> Handle(GetPurchasedTicketsForEventQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
