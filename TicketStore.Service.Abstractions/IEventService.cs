using TicketStore.Domain;

namespace TicketStore.Service.Abstractions
{
    public interface IEventService
    {
        public Task<Event> CreateAsync(Event anEvent);

        public Task<Event> UpdateAsync(Event anEvent);

        public Task<Event> GetByIdAsync(Guid? id);

        public Task<PagedResult<Event>> GetPagedAsync(Paging paging);

        public Task<PagedResult<Event>> GetFilteredAsync(Paging paging, EventFilter filter);

    }
}
