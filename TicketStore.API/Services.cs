using TicketStore.API.DTO.Mapping;

namespace TicketStore.API
{
    public static class Services
    {
        public static void RegisterApiDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
        }
    }
}
