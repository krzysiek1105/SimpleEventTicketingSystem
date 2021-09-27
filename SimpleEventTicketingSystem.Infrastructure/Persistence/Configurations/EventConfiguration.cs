using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEventTicketingSystem.Domain.Entities;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Tickets).WithOne(t => t.Event);
            builder.Metadata.FindNavigation(nameof(Event.Tickets)).SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
