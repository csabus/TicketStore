namespace TicketStore.API.Dto.Ticket
{
    public class TicketGroupByTypeDetails
    {
        public TicketTypeDetails Type { get; set; } = null!;

        public int Count { get; set; }
    }
}
