using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SimpleEventTicketingSystem.Domain.Persistence;
using SimpleEventTicketingSystem.Infrastructure.Persistence;

namespace SimpleEventTicketingSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<DatabaseContext>(builder => builder.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddTransient<IEventsRepository, EventsRepository>();
            services.AddTransient<ITicketsRepository, TicketsRepository>();
            return services;
        }
    }
}
