using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleEventTicketingSystem.Domain;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence.Configurations
{
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasKey(entity => entity.Id);
        }
    }
}
