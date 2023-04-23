using AutoMapper;
using TicketStore.Domain;
using TicketStore.Domain.Enum;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository.Mapping
{
    public class TicketStoreMapper: Profile
    {
        public TicketStoreMapper()
        {
            CreateMap<DbApplicationUser, ApplicationUser>();
            CreateMap<ApplicationUser, DbApplicationUser>();
            
            CreateMap<DbApplicationRole, ApplicationRole>();
            CreateMap<ApplicationRole, DbApplicationRole>();

            CreateMap<DbVenue, Venue>();
            CreateMap<Venue, DbVenue>();

            CreateMap<DbAddress, Address>();
            CreateMap<Address, DbAddress>();

            CreateMap<DbEvent, Event>();
            CreateMap<Event, DbEvent>();

            CreateMap<DbTicketType, TicketType>();
            CreateMap<TicketType, DbTicketType>();

            CreateMap<DbTicket, Ticket>()
                .ForMember(
                    t => t.Status,
                    ex => ex.MapFrom(t => (TicketStatus) Enum.ToObject(typeof(TicketStatus), t.Status))
                );
            CreateMap<Ticket, DbTicket>()
                .ForMember(
                    t => t.Status,
                    ex => ex.MapFrom(t => (int) t.Status)
                );

        }
    }
}
