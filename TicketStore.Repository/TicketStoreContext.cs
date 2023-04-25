using Microsoft.EntityFrameworkCore;
using TicketStore.Domain.Enum;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository
{
    public class TicketStoreContext : DbContext, ITicketStoreContext
    {
        public DbSet<DbApplicationUser> ApplicationUsers { get; set; }
        public DbSet<DbApplicationRole> Roles { get; set; }
        public DbSet<DbVenue> Venues { get; set; }
        public DbSet<DbEvent> Events { get; set; }
        public DbSet<DbTicketType> TicketTypes { get; set; }
        public DbSet<DbTicketStatus> TicketStates { get; set; }
        public DbSet<DbTicket> Tickets { get; set; }

        #pragma warning disable CS8618
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

            modelBuilder.Entity<DbTicket>()
                .HasOne(t => t.Event)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<DbTicket>()
                .HasOne(t => t.Type)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<DbTicketStatus>()
                .HasData(
                    Enum.GetValues(typeof(TicketStatus))
                        .OfType<TicketStatus>()
                        .Select(ts => new DbTicketStatus() { Id = (int)ts, Name = ts.ToString() })
                        .ToArray()
                        );
        }
        

    }
}
