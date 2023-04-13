using TicketStore.Domain;

namespace TicketStore.Repository.Abstractions
{
    public interface IVenueRepository
    {
        public Task<Venue> CreateAsync(Venue venue);
    }
}
