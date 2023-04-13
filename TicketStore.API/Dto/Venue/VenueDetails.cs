using TicketStore.Domain;

namespace TicketStore.API.Dto.Venue
{
    public class VenueDetails
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Address Address { get; set; } = null!;
    }
}
