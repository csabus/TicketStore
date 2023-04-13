using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Repository.Entities;

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
    }
}
