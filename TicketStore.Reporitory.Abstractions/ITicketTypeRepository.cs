using TicketStore.Domain;

namespace TicketStore.Repository.Abstractions
{
    public interface ITicketTypeRepository
    {
        public Task<TicketType> CreateAsync(TicketType ticketType);
        
        public Task<TicketType> GetByIdAsync(Guid? id);

        public Task<TicketType> UpdateAsync(TicketType ticketType);
    }
}
