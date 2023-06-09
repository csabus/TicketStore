﻿using Microsoft.EntityFrameworkCore;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository
{
    public interface ITicketStoreContext
    {
        DbSet<DbApplicationUser> ApplicationUsers { get; set; }

        DbSet<DbApplicationRole> Roles { get; set; }

        DbSet<DbVenue> Venues { get; set; }

        DbSet<DbEvent> Events { get; set; }

        DbSet<DbTicketType> TicketTypes { get; set; }

        DbSet<DbTicketStatus> TicketStates { get; set; }

        DbSet<DbTicket> Tickets { get; set; } 
    }
}
