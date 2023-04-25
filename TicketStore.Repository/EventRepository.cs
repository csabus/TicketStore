using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Repository.Entities;
using System.Linq.Dynamic.Core;

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

        public async Task<Event> UpdateAsync(Event anEvent)
        {
            var dbEvent = _dbContext.Events.FirstOrDefault(e => e.Id == anEvent.Id);
            if(dbEvent != null)
            { 
                dbEvent.Title = anEvent.Title;
                dbEvent.Description = anEvent.Description;
                dbEvent.DateTime = anEvent.DateTime;
                dbEvent.Venue = _mapper.Map<Venue, DbVenue>(anEvent.Venue);

                ((DbContext)_dbContext).Entry(dbEvent.Venue).State = EntityState.Unchanged;
                await ((DbContext)_dbContext).SaveChangesAsync();

                var result = _mapper.Map<DbEvent, Event>(dbEvent);
                return result;
            }

            return null!;
        }

        public Task<Event> GetByIdAsync(Guid? id)
        {
            var dbEvent = _dbContext.Events
                .Where(e => e.Id == id)
                .Include(e => e.Venue)
                .FirstOrDefault();
            if(dbEvent != null)
            {
                return Task.FromResult(_mapper.Map<DbEvent, Event>(dbEvent));
            }

            return Task.FromResult<Event>(null!);

        }

        public Task<Domain.PagedResult<Event>> GetPagedAsync(Paging paging)
        {
            var dbEventList = _dbContext.Events
                .Skip(paging.Page * paging.PageSize)
                .Take(paging.PageSize)
                .Include(e => e.Venue)
                .OrderBy(paging.GetOrderByString("title"))
                .ToList();
            var pagedResult = new Domain.PagedResult<Event>
            {
                Result = _mapper.Map<List<DbEvent>, List<Event>>(dbEventList),
                TotalCount = _dbContext.Events.Count(),
                Page = paging.Page,
                PageSize = paging.PageSize
            };
            return Task.FromResult(pagedResult);
        }
    }
}
