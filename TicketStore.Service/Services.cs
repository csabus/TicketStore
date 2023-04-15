using Microsoft.Extensions.DependencyInjection;
using TicketStore.Service.Abstractions;

namespace TicketStore.Service
{
    public static class Services
    {
        public static void RegisterServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IVenueService, VenueService>();
            services.AddTransient<IEventService, EventService>();
        }

    }
}
