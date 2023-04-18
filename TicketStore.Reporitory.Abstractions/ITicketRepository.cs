using TicketStore.Domain;

namespace TicketStore.Repository.Abstractions
{
    public interface ITicketRepository
    {
        public Task<TicketType> CreateTypeAsync(TicketType ticketType);
        
        public Task<TicketType> GetTypeByIdAsync(Guid id);

        public Task<TicketType> UpdateypeAsync(TicketType ticketType);
    }
}
