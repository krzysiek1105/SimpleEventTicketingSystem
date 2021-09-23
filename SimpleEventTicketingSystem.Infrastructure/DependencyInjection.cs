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
            services.AddTransient<IEventsRepository, EventsRepository>();
            return services;
        }
    }
}
