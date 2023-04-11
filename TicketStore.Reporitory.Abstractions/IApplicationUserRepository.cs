using Microsoft.AspNetCore.Identity;
using TicketStore.Domain;

namespace TicketStore.Repository.Abstractions
{
    public interface IApplicationUserRepository
    {
        public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken);
        
        public Task<ApplicationUser> GetByUsernameAsync(string normalizedUsername, CancellationToken cancellationToken);
        
        public Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken);

    }
}
