using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SimpleEventTicketingSystem.Application.Tickets.Queries
{
    public class GetTicketAvailabilityForEventQuery : IRequest
    {
        public Guid EventId { get; set; }
    }

    public class GetTicketAvailabilityForEventQueryHandler : IRequestHandler<GetPurchasedTicketsForEventQuery>
    {
        public Task<Unit> Handle(GetPurchasedTicketsForEventQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
