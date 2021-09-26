using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleEventTicketingSystem.Application.Events.Commands;
using SimpleEventTicketingSystem.Application.Events.Queries;

namespace SimpleEventTicketingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEventCommand createEventCommand)
        {
            return Ok(await _mediator.Send(createEventCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteEventCommand
            {
                Id = id
            });

            return NoContent();
        }

        [HttpPut("events/{eventId}/pool")]
        public async Task<IActionResult> IncrementTicketPool(Guid eventId, IncrementTicketPoolCommand incrementTicketPoolCommand)
        {
            incrementTicketPoolCommand.EventId = eventId;
            return Ok(await _mediator.Send(incrementTicketPoolCommand));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetEventsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _mediator.Send(new GetEventQuery
            {
                Id = id
            }));
        }
    }
}
