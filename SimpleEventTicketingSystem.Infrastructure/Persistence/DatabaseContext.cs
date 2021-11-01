using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimpleEventTicketingSystem.Domain.Entities;

namespace SimpleEventTicketingSystem.Infrastructure.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Event> Events { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
