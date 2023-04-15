using TicketStore.API.Dto.Venue;

namespace TicketStore.API.Dto.Event
{
    public class EventDetails
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime DateTime { get; set; }

        public VenueDetails Venue { get; set; } = null!;

    }
}
