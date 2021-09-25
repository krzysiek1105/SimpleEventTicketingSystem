using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEventTicketingSystem.Domain;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(ticket => ticket.Id);
            builder.HasOne(ticket => ticket.Event).WithMany(e => e.Tickets);
        }
    }
}
