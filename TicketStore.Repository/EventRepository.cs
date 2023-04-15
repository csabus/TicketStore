using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ITicketStoreContext _dbContext;
        public readonly IMapper _mapper;

        public EventRepository(ITicketStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Event> CreateAsync(Event anEvent)
        {
            var dbEvent = _mapper.Map<Event, DbEvent>(anEvent);
            await _dbContext.Events.AddAsync(dbEvent);
            
            ((DbContext)_dbContext).Entry(dbEvent.Venue).State = EntityState.Unchanged;
            await ((DbContext)_dbContext).SaveChangesAsync();
            
            return _mapper.Map<DbEvent, Event>(dbEvent);
        }
    }
}
