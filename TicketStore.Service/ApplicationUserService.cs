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
    }
}
