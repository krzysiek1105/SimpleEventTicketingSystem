using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleEventTicketingSystem.Domain;

namespace SimpleEventTicketingSystem.API
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case EntityDoesNotExistException entityDoesNotExistException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Result = new ObjectResult(entityDoesNotExistException.Message);

                    context.ExceptionHandled = true;
                    break;
                case TicketDomainException ticketDomainException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Result = new ObjectResult(ticketDomainException.Message);

                    context.ExceptionHandled = true;
                    break;
                case EventDomainException eventDomainException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Result = new ObjectResult(eventDomainException.Message);

                    context.ExceptionHandled = true;
                    break;
                default:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Result = new ObjectResult("Internal server error");

                    context.ExceptionHandled = true;
                    break;
            }
        }
    }
}
