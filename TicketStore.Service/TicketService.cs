﻿using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Service.Abstractions;

namespace TicketStore.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<bool> CreateAsync(Ticket ticket, int count)
        {
            return _ticketRepository.CreateAsync(ticket, count);
        }

        public Task<Ticket> GetByIdAsync(Guid id)
        {
            return _ticketRepository.GetByIdAsync(id);
        }

        public Task<bool> ValidateAsync(Guid ticketId, Guid eventId)
        {
            return _ticketRepository.ValidateAsync(ticketId, eventId);
        }
    }
}
