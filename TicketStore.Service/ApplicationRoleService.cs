using Microsoft.AspNetCore.Identity;
using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Service.Abstractions;

namespace TicketStore.Service
{
    internal class ApplicationRoleService : IApplicationRoleService
    {
        private readonly IApplicationRoleRepository _applicaRoleRepository;

        public ApplicationRoleService(IApplicationRoleRepository applicaRoleRepository)
        {
            _applicaRoleRepository = applicaRoleRepository;
        }

        public Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return _applicaRoleRepository.CreateAsync(role, cancellationToken);
        }

        public Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return _applicaRoleRepository.FindByIdAsync(roleId, cancellationToken);
        }

        public Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return _applicaRoleRepository.FindByNameAsync(normalizedRoleName, cancellationToken);
        }
    }
}
