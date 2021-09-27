using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEventTicketingSystem.Domain.Entities;
using SimpleEventTicketingSystem.Domain.ValueObjects;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(ticket => ticket.Id);
            builder.OwnsOne(ticket => ticket.Email).Property(email => email.Value).HasColumnName(nameof(Email)).IsRequired();
            builder.OwnsOne(ticket => ticket.FirstName).Property(firstName => firstName.Value).HasColumnName(nameof(FirstName)).IsRequired();
            builder.OwnsOne(ticket => ticket.LastName).Property(lastName => lastName.Value).HasColumnName(nameof(LastName)).IsRequired();
            builder.HasOne(ticket => ticket.Event).WithMany(e => e.Tickets);
        }
    }
}
