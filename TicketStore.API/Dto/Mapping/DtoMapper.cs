using AutoMapper;
using TicketStore.API.Dto;
using TicketStore.API.Dto.Account;
using TicketStore.API.Dto.Event;
using TicketStore.API.Dto.Ticket;
using TicketStore.API.Dto.Venue;
using TicketStore.Domain;
using TicketStore.Domain.Enum;

namespace TicketStore.API.DTO.Mapping
{
    public class DtoMapper: Profile
    {
        public DtoMapper()
        {
            CreateMap<PagingRequest, Paging>()
                .ForMember(p => p.Page, opt => opt.NullSubstitute(0))
                .ForMember(p => p.PageSize, opt => opt.NullSubstitute(20));

            CreateMap<PagedResult<Venue>, PagedResult<VenueDetails>>();
            CreateMap<PagedResult<Event>, PagedResult<EventDetails>>();

            CreateMap<RegisterUserRequest, ApplicationUser>();
            CreateMap<ApplicationUser, AuthenticatedUser>();
            
            CreateMap<CreateVenueRequest, Venue>();
            CreateMap<UpdateVenueRequest, Venue>();

            CreateMap<Venue, VenueDetails>();

            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>();

            CreateMap<CreateEventRequest, Event>();
            CreateMap<UpdateEventRequest, Event>();
            
            CreateMap<Event, EventDetails>();

            CreateMap<CreateTicketTypeRequest, TicketType>();
            CreateMap<UpdateTicketTypeRequest, TicketType>();

            CreateMap<TicketType, TicketTypeDetails>();

            CreateMap<CreateTicketsRequest, Ticket>()
                .ForMember(
                    t => t.IsAvailable, 
                    opt => opt.NullSubstitute(true))
                .ForMember(
                    t => t.Status,
                    opt => opt.MapFrom(t => string.IsNullOrEmpty(t.Status) ? 
                                                TicketStatus.Available : 
                                                Enum.Parse(typeof(TicketStatus), t.Status!, true)))
                .ForMember(
                    t => t.Event, 
                    opt => opt.MapFrom(t => new Event() { Id = t.EventId!.Value }))
                .ForMember(
                    t => t.Type, 
                    opt => opt.MapFrom(t => new TicketType() { Id = t.TicketTypeId!.Value }));

            CreateMap<Ticket, TicketDetails>();

            CreateMap<TicketGroupByType, TicketGroupByTypeDetails>();
            CreateMap<AvailableTickets, AvailableTicketsDetails>();
        }
    }
}
