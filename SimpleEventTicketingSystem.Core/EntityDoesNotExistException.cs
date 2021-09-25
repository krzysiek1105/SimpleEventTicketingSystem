using System;
using System.Runtime.Serialization;

namespace SimpleEventTicketingSystem.Domain
{
    [Serializable]
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException()
        {
        }

        public EntityDoesNotExistException(string message) : base(message)
        {
        }

        public EntityDoesNotExistException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EntityDoesNotExistException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
