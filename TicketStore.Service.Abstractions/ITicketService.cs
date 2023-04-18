using TicketStore.Domain;

namespace TicketStore.Service.Abstractions
{
    public interface ITicketService
    {
        public Task<TicketType> CreateTypeAsync(TicketType ticketType);

        public Task<TicketType> GetTypeByIdAsync(Guid id);

        public Task<TicketType> UpdateTypeAsync(TicketType ticketType);
    }
}
