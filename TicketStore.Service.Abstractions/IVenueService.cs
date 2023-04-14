using TicketStore.Domain;

namespace TicketStore.Service.Abstractions
{
    public interface IVenueService
    {
        public Task<Venue> CreateAsync(Venue venue);
        
        public Task<Venue> UpdateAsync(Venue venue);

        public Task<Venue> GetByIdAsync(Guid id);
    }
}
