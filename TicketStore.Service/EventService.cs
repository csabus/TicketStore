using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Service.Abstractions;

namespace TicketStore.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<Event> CreateAsync(Event anEvent)
        {
            return _eventRepository.CreateAsync(anEvent);
        }

        public Task<Event> UpdateAsync(Event anEvent)
        {
            return _eventRepository.UpdateAsync(anEvent);
        }

        public Task<Event> GetByIdAsync(Guid? id)
        {
            return _eventRepository.GetByIdAsync(id);
        }

        public Task<PagedResult<Event>> GetPagedAsync(Paging paging)
        {
            return _eventRepository.GetPagedAsync(paging);
        }

        public Task<PagedResult<Event>> GetFilteredAsync(Paging paging, EventFilter filter)
        {
            return _eventRepository.GetFilteredAsync(paging, filter);
        }


    }
}
