using TicketStore.Domain;

namespace TicketStore.Repository.Abstractions
{
    public interface ITicketRepository
    {
        Task<bool> CreateAsync(Ticket ticket, int count);

        Task<Ticket> GetByIdAsync(Guid id);

        Task<bool> ValidateAsync(Guid ticketId, Guid eventId);

        Task<Ticket> BuyAsync(Guid eventId, Guid ticketTypeId);
    }
}
