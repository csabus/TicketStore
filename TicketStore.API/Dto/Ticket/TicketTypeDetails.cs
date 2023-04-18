namespace TicketStore.API.Dto.Ticket
{
    public class TicketTypeDetails
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public Domain.Venue Venue { get; set; } = null!;
    }
}
