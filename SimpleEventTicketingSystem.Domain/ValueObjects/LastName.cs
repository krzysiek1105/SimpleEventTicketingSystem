using System.Collections.Generic;
using SimpleEventTicketingSystem.Domain.Exceptions;

namespace SimpleEventTicketingSystem.Domain.ValueObjects
{
    public class LastName : ValueObject
    {
        public string Value { get; private set; }

        public LastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new FirstNameDomainException("Last name cannot be null or empty");
            }

            if (value.Length > 100)
            {
                throw new FirstNameDomainException("Last name is too long");
            }

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
