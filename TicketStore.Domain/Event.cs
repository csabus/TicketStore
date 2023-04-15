namespace TicketStore.Domain
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime DateTime { get; set; }

        public Venue Venue { get; set; } = null!;

    }
}
