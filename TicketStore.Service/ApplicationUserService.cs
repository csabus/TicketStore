using Microsoft.AspNetCore.Identity;
using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Service.Abstractions;

namespace TicketStore.Service
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository _applUserRepository;

        public ApplicationUserService(IApplicationUserRepository applUserRepository)
        {
            _applUserRepository = applUserRepository;
        }

        public Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return _applUserRepository.CreateAsync(user, cancellationToken);
        }

        public Task<ApplicationUser> GetByUsernameAsync(string normalizedUsername, CancellationToken cancellationToken)
        {
            return _applUserRepository.GetByUsernameAsync(normalizedUsername, cancellationToken);
        }

        public Task<IList<string>> GetRolesAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var roles = user.Roles.Select(role => role.NormalizedName).ToList();
            return Task.FromResult((IList<string>)roles);
        }

        public Task<IList<ApplicationUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            return _applUserRepository.GetUsersInRoleAsync(roleName, cancellationToken);
        }

        public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName, CancellationToken cancellationToken)
        {
            var result = user.Roles.Any(role => role.NormalizedName == roleName);
            return Task.FromResult(result);
        }
    }
}
