using TicketStore.Domain;
using TicketStore.Repository.Abstractions;
using TicketStore.Service.Abstractions;

namespace TicketStore.Service
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository _venueRepository;

        public VenueService(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        public Task<Venue> CreateAsync(Venue venue)
        {
            return _venueRepository.CreateAsync(venue);
        }

        public Task<Venue> GetByIdAsync(Guid id)
        {
            return _venueRepository.GetByIdAsync(id);
        }

        public Task<Venue> UpdateAsync(Venue venue)
        {
            return _venueRepository.UpdateAsync(venue);
        }
    }
}
