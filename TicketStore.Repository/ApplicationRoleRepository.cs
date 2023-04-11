using Microsoft.AspNetCore.Identity;
using TicketStore.Domain;
using TicketStore.Repository.Abstractions;

namespace TicketStore.Repository
{
    internal class ApplicationRoleRepository : IApplicationRoleRepository
    {
        public Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
