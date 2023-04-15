using TicketStore.Domain;

namespace TicketStore.Repository.Abstractions
{
    public interface IEventRepository
    {
        public Task<Event> CreateAsync(Event anEvent);
    }
}
