using Microsoft.EntityFrameworkCore;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository
{
    public class TicketStoreContext : DbContext, ITicketStoreContext
    {
        public DbSet<DbApplicationUser> ApplicationUsers { get; set; }
        public DbSet<DbApplicationRole> Roles { get; set; }
        public DbSet<DbVenue> Venues { get; set; }

        public TicketStoreContext(DbContextOptions<TicketStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DbApplicationUser>()
                            .HasMany(u => u.Roles)
                            .WithMany(r => r.Users)
                            .UsingEntity(ur => ur.ToTable("application_user_role"));
        }


    }
}
