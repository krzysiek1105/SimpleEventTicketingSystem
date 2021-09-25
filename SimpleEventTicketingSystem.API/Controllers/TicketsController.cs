using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleEventTicketingSystem.Application.Tickets.Commands;

namespace SimpleEventTicketingSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BuyTicketCommand buyTicketCommand)
        {
            return Ok(await _mediator.Send(buyTicketCommand));
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
