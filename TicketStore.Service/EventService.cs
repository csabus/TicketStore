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

        public Task<Event> GetByIdAsync(Guid id)
        {
            return _eventRepository.GetByIdAsync(id);
        }

        public Task<Event> UpdateAsync(Event anEvent)
        {
            return _eventRepository.UpdateAsync(anEvent);
        }

    }
}
