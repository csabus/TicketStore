namespace TicketStore.Domain
{
    public class TicketGroupByType
    {
        public TicketType Type { get; set; } = null!;

        public int Count { get; set; }
    }
}
