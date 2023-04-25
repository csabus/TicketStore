using TicketStore.Domain;

namespace TicketStore.Repository.Abstractions
{
    public interface IEventRepository
    {
        public Task<Event> CreateAsync(Event anEvent);
        
        public Task<Event> UpdateAsync(Event anEvent);

        public Task<Event> GetByIdAsync(Guid? id);

        public Task<PagedResult<Event>> GetPagedAsync(Paging paging);
    }
}
