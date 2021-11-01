using System;
using System.Runtime.Serialization;

namespace SimpleEventTicketingSystem.Domain.Exceptions
{
    public class EmailDomainException : DomainException
    {
        public EmailDomainException()
        {
        }

        public EmailDomainException(string message) : base(message)
        {
        }

        public EmailDomainException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EmailDomainException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
