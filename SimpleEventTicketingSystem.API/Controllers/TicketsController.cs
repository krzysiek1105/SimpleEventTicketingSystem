using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleEventTicketingSystem.Application.Tickets.Commands;

namespace SimpleEventTicketingSystem.API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("events/{eventId}/tickets")]
        public async Task<IActionResult> Create(Guid eventId, BuyTicketCommand buyTicketCommand)
        {
            buyTicketCommand.EventId = eventId;
            return Ok(await _mediator.Send(buyTicketCommand));
        }

        [HttpDelete("events/{eventId}/tickets/{id}")]
        public async Task<IActionResult> Delete(Guid eventId, Guid id)
        {
            await _mediator.Send(new ReturnTicketCommand
            {
                EventId = eventId,
                Id = id
            });

            return Ok();
        }
    }
}
