using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Repository.Entities;
using TicketStore.Repository.Migrations;

namespace TicketStore.Repository
{
    public class VenueRepository : IVenueRepository
    {
        private readonly ITicketStoreContext _dbContext;
        public readonly IMapper _mapper;

        public VenueRepository(ITicketStoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Venue> CreateAsync(Venue venue)
        {
            var dbVenue = _mapper.Map<Venue, DbVenue>(venue);
            await _dbContext.Venues.AddAsync(dbVenue);
            await((DbContext)_dbContext).SaveChangesAsync();

            var result = _mapper.Map<DbVenue, Venue>(dbVenue);
            return result;
        }

        public async Task<Venue> UpdateAsync(Venue venue)
        {
            var dbVenue = _dbContext.Venues.FirstOrDefault(v => v.Id == venue.Id);
            if (dbVenue != null)
            {
                dbVenue.Name = venue.Name;
                dbVenue.Description = venue.Description;
                dbVenue.Address = _mapper.Map<Address, DbAddress>(venue.Address);
                await ((DbContext)_dbContext).SaveChangesAsync();
                
                var result = _mapper.Map<DbVenue, Venue>(dbVenue);
                return result;
            }

            return null!;
        }

        public Task<Venue> GetByIdAsync(Guid id)
        {
            var dbVenueFound = _dbContext.Venues.FirstOrDefault(v => v.Id == id);
            if (dbVenueFound != null)
            {
                return Task.FromResult(_mapper.Map<DbVenue, Venue>(dbVenueFound));
            }
            
            return Task.FromResult<Venue>(null!);
        }
    }
}
