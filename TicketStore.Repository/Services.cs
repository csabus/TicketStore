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
            services.AddTransient<IApplicationRoleRepository, ApplicationRoleRepository>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<TicketStoreMapper>();
            });
        }

    }
}
