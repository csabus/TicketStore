﻿using TicketStore.Domain;

namespace TicketStore.Service.Abstractions
{
    public interface ITicketService
    {
        Task<bool> CreateAsync(Ticket ticket, int count);

        Task<Ticket> GetByIdAsync(Guid id);

        Task<bool> ValidateAsync(Guid ticketId, Guid eventId);

        Task<Ticket> BuyAsync(Guid eventId, Guid ticketTypeId);

        Task<AvailableTickets> GetAvailableTicketsAsync(Guid eventId);

    }
}
