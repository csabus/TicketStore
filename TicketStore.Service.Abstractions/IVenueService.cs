using TicketStore.Domain;

namespace TicketStore.Service.Abstractions
{
    public interface IVenueService
    {
        public Task<Venue> CreateAsync(Venue venue);
    }
}
