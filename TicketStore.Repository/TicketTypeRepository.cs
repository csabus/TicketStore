using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Repository.Entities;

namespace TicketStore.Repository
{
    public class TicketTypeRepository : ITicketTypeRepository
    {
        private readonly ITicketStoreContext _dbContext;
        private readonly IMapper _mapper;

        public TicketTypeRepository(ITicketStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TicketType> CreateAsync(TicketType ticketType)
        {
            var dbTicketType = _mapper.Map<TicketType, DbTicketType>(ticketType);
            await _dbContext.TicketTypes.AddAsync(dbTicketType);
            
            ((DbContext)_dbContext).Entry(dbTicketType.Venue).State = EntityState.Unchanged;
            await ((DbContext)_dbContext).SaveChangesAsync();

            return _mapper.Map<DbTicketType, TicketType>(dbTicketType);
        }

        public Task<TicketType> GetByIdAsync(Guid? id)
        {
            var dbTicketType = _dbContext.TicketTypes
                .Where(t => t.Id == id)
                .Include(t => t.Venue)
                .FirstOrDefault();
            if(dbTicketType != null)
            {
                return Task.FromResult(_mapper.Map<DbTicketType, TicketType>(dbTicketType));
            }

            return Task.FromResult<TicketType>(null!);
        }

        public async Task<TicketType> UpdateAsync(TicketType ticketType)
        {
            var dbTicketType = _dbContext.TicketTypes.FirstOrDefault(e => e.Id == ticketType.Id);
            if (dbTicketType != null)
            {
                dbTicketType.Name = ticketType.Name;
                dbTicketType.Description = ticketType.Description;
                dbTicketType.Venue = _mapper.Map<Venue, DbVenue>(ticketType.Venue);

                ((DbContext)_dbContext).Entry(dbTicketType.Venue).State = EntityState.Unchanged;
                await((DbContext)_dbContext).SaveChangesAsync();

                return _mapper.Map<DbTicketType, TicketType>(dbTicketType);
            }

            return null!;
        }
    }
}
