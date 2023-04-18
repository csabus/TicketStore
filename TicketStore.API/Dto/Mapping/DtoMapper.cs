using AutoMapper;
using TicketStore.API.Dto;
using TicketStore.API.Dto.Account;
using TicketStore.API.Dto.Event;
using TicketStore.API.Dto.Ticket;
using TicketStore.API.Dto.Venue;
using TicketStore.Domain;

namespace TicketStore.API.DTO.Mapping
{
    public class DtoMapper: Profile
    {
        public DtoMapper()
        {
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
        }
    }
}
