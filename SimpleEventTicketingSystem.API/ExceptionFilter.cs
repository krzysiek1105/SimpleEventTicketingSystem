using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleEventTicketingSystem.Domain.Exceptions;

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
                case DomainException domainException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Result = new ObjectResult(domainException.Message);

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
