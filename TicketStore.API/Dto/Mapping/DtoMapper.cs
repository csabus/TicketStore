using AutoMapper;
using TicketStore.API.Dto.Account;
using TicketStore.Domain;

namespace TicketStore.API.DTO.Mapping
{
    public class DtoMapper: Profile
    {
        public DtoMapper()
        {
            CreateMap<RegisterUserRequest, ApplicationUser>();
            CreateMap<ApplicationUser, AuthenticatedUser>();
        }
    }
}
