using Microsoft.EntityFrameworkCore;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository
{
    public class TicketStoreContext : DbContext, ITicketStoreContext
    {
        public DbSet<DbApplicationUser> ApplicationUsers { get; set; }

        public TicketStoreContext(DbContextOptions<TicketStoreContext> options) : base(options)
        {
        }

    }
}
