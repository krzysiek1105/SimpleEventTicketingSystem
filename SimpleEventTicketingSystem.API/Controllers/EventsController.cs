using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleEventTicketingSystem.Application.Events.Commands;

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
        public async Task<IActionResult> Create()
        {
            return Ok(await _mediator.Send(new CreateEventCommand
            {
                TicketPoolCapacity = new Random().Next(1, 16)
            }));
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
