using AutoMapper;
using TicketStore.Domain;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository.Mapping
{
    public class TicketStoreMapper: Profile
    {
        public TicketStoreMapper()
        {
            CreateMap<DbApplicationUser, ApplicationUser>();
            CreateMap<ApplicationUser, DbApplicationUser>();
        }
    }
}
