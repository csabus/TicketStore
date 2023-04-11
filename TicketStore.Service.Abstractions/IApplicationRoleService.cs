using Microsoft.AspNetCore.Identity;
using TicketStore.Domain;

namespace TicketStore.Service.Abstractions
{
    public interface IApplicationRoleService
    {
        public Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken);

        public Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken);

        public Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken);

    }
}
