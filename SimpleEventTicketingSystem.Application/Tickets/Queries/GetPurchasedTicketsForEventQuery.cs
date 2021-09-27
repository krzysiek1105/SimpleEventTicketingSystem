using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Tickets.Queries
{
    public class PurchasedTicketResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class PurchasedTicketsForEventResponse
    {
        public Guid EventId { get; set; }
        public IEnumerable<PurchasedTicketResponse> Tickets { get; set; }
    }

    public class GetPurchasedTicketsForEventQuery : IRequest<PurchasedTicketsForEventResponse>
    {
        public Guid EventId { get; set; }
    }

    public class GetPurchasedTicketsForEventQueryHandler : IRequestHandler<GetPurchasedTicketsForEventQuery, PurchasedTicketsForEventResponse>
    {
        private readonly IEventsRepository _eventsRepository;

        public GetPurchasedTicketsForEventQueryHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public Task<PurchasedTicketsForEventResponse> Handle(GetPurchasedTicketsForEventQuery request, CancellationToken cancellationToken)
        {
            var @event = _eventsRepository.Get(request.EventId);

            return Task.FromResult(new PurchasedTicketsForEventResponse
            {
                EventId = @event.Id,
                Tickets = @event.Tickets.Select(ticket => new PurchasedTicketResponse
                {
                    Id = ticket.Id,
                    Email = ticket.Email,
                    FirstName = ticket.FirstName,
                    LastName = ticket.LastName
                })
            });
        }
    }
}
