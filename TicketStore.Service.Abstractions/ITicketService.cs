using TicketStore.Domain;

namespace TicketStore.Service.Abstractions
{
    public interface ITicketService
    {
        Task<bool> CreateAsync(Ticket ticket, int count);
    }
}
