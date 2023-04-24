using TicketStore.Domain;

namespace TicketStore.Service.Abstractions
{
    public interface ITicketTypeService
    {
        public Task<TicketType> CreateAsync(TicketType ticketType);

        public Task<TicketType> GetByIdAsync(Guid? id);

        public Task<TicketType> UpdateAsync(TicketType ticketType);
    }
}
