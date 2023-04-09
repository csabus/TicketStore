using Microsoft.EntityFrameworkCore;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository
{
    public interface ITicketStoreContext
    {
        DbSet<DbApplicationUser> ApplicationUsers { get; set; }
    }
}
