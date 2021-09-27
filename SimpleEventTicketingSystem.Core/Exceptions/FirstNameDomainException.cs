using System;
using System.Runtime.Serialization;

namespace SimpleEventTicketingSystem.Domain.Exceptions
{
    public class FirstNameDomainException : DomainException
    {
        public FirstNameDomainException()
        {
        }

        public FirstNameDomainException(string message) : base(message)
        {
        }

        public FirstNameDomainException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FirstNameDomainException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}