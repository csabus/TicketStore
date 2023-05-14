namespace TicketStore.Domain
{
    public class AvailableTickets
    {
        public Event Event { get; set; } = null!;

        public List<TicketGroupByType> GroupByType { get; set;} = new List<TicketGroupByType>();
    }
}
