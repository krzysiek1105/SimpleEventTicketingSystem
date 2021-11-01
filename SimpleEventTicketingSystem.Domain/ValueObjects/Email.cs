using System.Collections.Generic;
using System.Text.RegularExpressions;
using SimpleEventTicketingSystem.Domain.Exceptions;

namespace SimpleEventTicketingSystem.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        private const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public string Value { get; private set; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmailDomainException("Email cannot be null or empty");
            }

            if (!Regex.IsMatch(value, EmailRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled))
            {
                throw new EmailDomainException("Email is invalid");
            }

            if (value.Length > 100)
            {
                throw new EmailDomainException("Email is too long");
            }

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
