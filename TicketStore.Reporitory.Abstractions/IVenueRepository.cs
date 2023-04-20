using TicketStore.Domain;

namespace TicketStore.Repository.Abstractions
{
    public interface IVenueRepository
    {
        public Task<Venue> CreateAsync(Venue venue);
        
        public Task<Venue> UpdateAsync(Venue venue);

        public Task<Venue> GetByIdAsync(Guid id);
        
        public Task<PagedResult<Venue>> GetPagedAsync(Paging paging);
    }
}
