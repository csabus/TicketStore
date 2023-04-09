using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly ITicketStoreContext _dbContext;
        public readonly IMapper _mapper;

        public ApplicationUserRepository(ITicketStoreContext ticketStoreContext, IMapper mapper)
        {
            _dbContext = ticketStoreContext;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var dbUser = _mapper.Map<ApplicationUser, DbApplicationUser>(user);
            await _dbContext.ApplicationUsers.AddAsync(dbUser, cancellationToken);
            await ((DbContext)_dbContext).SaveChangesAsync(cancellationToken);
            
            return IdentityResult.Success;
        }

        public Task<ApplicationUser> GetByUsernameAsync(string normalizedUsername, CancellationToken cancellationToken)
        {
            var dbUser = _dbContext.ApplicationUsers.FirstOrDefault(u => u.NormalizedUsername == normalizedUsername);
            if (dbUser != null)
            {
                var applicationUser = _mapper.Map<DbApplicationUser, ApplicationUser>(dbUser);
                return Task.FromResult(applicationUser);
            }
            return Task.FromResult(new ApplicationUser());
        }
    }
}
