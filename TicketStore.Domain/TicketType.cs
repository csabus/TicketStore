namespace TicketStore.Domain
{
    public class TicketType
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public Venue Venue { get; set; } = null!;
    }
}
