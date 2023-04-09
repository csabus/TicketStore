using TicketStore.Domain;

namespace TicketStore.Service.Abstractions
{
    public interface ITokenService
    {
        public string CreateToken(ApplicationUser user);
    }
}
