using Microsoft.Extensions.DependencyInjection;
using TicketStore.Repository.Abstractions;
using TicketStore.Repository.Mapping;

namespace TicketStore.Repository
{
    public static class Services
    {
        public static void RegisterRepositoryDependencies(this IServiceCollection services)
        {
            services.AddTransient<ITicketStoreContext, TicketStoreContext>();
            services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddTransient<IVenueRepository, VenueRepository>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<ITicketTypeRepository, TicketTypeRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<TicketStoreMapper>();
            });
        }

    }
}
