using Microsoft.EntityFrameworkCore;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository
{
    public interface ITicketStoreContext
    {
        DbSet<DbApplicationUser> ApplicationUsers { get; set; }

        DbSet<DbApplicationRole> Roles { get; set; }

        DbSet<DbVenue> Venues { get; set; }

        DbSet<DbEvent> Events { get; set; }
    }
}
