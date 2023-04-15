using TicketStore.Domain;

namespace TicketStore.Service.Abstractions
{
    public interface IEventService
    {
        public Task<Event> CreateAsync(Event anEvent);
    }
}
