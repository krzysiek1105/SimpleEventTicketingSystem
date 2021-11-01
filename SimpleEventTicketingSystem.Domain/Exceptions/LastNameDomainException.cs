using System;
using System.Runtime.Serialization;

namespace SimpleEventTicketingSystem.Domain.Exceptions
{
    public class LastNameDomainException : DomainException
    {
        public LastNameDomainException()
        {
        }

        public LastNameDomainException(string message) : base(message)
        {
        }

        public LastNameDomainException(string message, Exception inner) : base(message, inner)
        {
        }

        protected LastNameDomainException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}