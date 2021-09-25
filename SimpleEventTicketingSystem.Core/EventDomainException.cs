using System;
using System.Runtime.Serialization;

namespace SimpleEventTicketingSystem.Domain
{
    [Serializable]
    public class EventDomainException : Exception
    {
        public EventDomainException()
        {
        }

        public EventDomainException(string message) : base(message)
        {
        }

        public EventDomainException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EventDomainException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
