using System;
using SimpleEventTicketingSystem.Domain.Entities;
using SimpleEventTicketingSystem.Domain.Exceptions;
using SimpleEventTicketingSystem.Domain.ValueObjects;
using Xunit;

namespace SimpleEventTicketingSystem.Tests
{
    public class EventTests
    {
        [Fact]
        public void ShouldNotCreateEmptyEvent()
        {
            Assert.Throws<EventDomainException>(() => new Event(0));
            Assert.Throws<EventDomainException>(() => new Event(-1));
        }

        [Fact]
        public void ShouldCreateEventWithGivenCapacity()
        {
            const int capacity = 5;
            var @event = new Event(capacity);

            Assert.Equal(capacity, @event.TicketPoolPoolCapacity);
        }

        [Fact]
        public void ShouldObtainFirstTicketAndThrowExceptionAfterTryingToObtainNextTicketBecauseOfEmptyPool()
        {
            var @event = new Event(1);

            var firstName = new FirstName("John");
            var lastName = new LastName("Doe");
            var email = new Email("jon.doe@example.com");

            var _ = @event.GetTicket(firstName, lastName, email);
            Assert.Throws<EventDomainException>(() => @event.GetTicket(firstName, lastName, email));
        }

        [Fact]
        public void ShouldReturnTicket()
        {
            var @event = new Event(1);

            var firstName = new FirstName("John");
            var lastName = new LastName("Doe");
            var email = new Email("jon.doe@example.com");

            var ticket = @event.GetTicket(firstName, lastName, email);
            Assert.Equal(1, @event.Tickets.Count);

            @event.ReturnTicket(ticket.Id);
            Assert.Equal(0, @event.Tickets.Count);
        }

        [Fact]
        public void ShouldThrowExceptionIfInvalidTicketToReturn()
        {
            var @event = new Event(1);
            Assert.Throws<EventDomainException>(() => @event.ReturnTicket(Guid.NewGuid()));
        }
    }
}
