using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SimpleEventTicketingSystem.Domain.Persistence;

namespace SimpleEventTicketingSystem.Application.Events.Commands
{
    public class DeleteEventCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IEventsRepository _eventsRepository;

        public DeleteEventCommandHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            _eventsRepository.Remove(request.Id);
            await _eventsRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
