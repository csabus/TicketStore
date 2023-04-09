using TicketStore.Domain;
using Microsoft.AspNetCore.Identity;

namespace TicketStore.Service.Abstractions
{
    public interface IApplicationUserService
    {
        public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken);
        public Task<ApplicationUser> GetByUsernameAsync(string normalizedUSername, CancellationToken cancellationToken);

    }
}
