using System;
using System.Runtime.Serialization;

namespace SimpleEventTicketingSystem.Domain.Exceptions
{
    [Serializable]
    public class TicketDomainException : DomainException
    {
        public TicketDomainException()
        {
        }

        public TicketDomainException(string message) : base(message)
        {
        }

        public TicketDomainException(string message, Exception inner) : base(message, inner)
        {
        }

        protected TicketDomainException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
