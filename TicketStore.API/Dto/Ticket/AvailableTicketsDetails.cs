using TicketStore.API.Dto.Event;

namespace TicketStore.API.Dto.Ticket
{
    public class AvailableTicketsDetails
    {
        public EventDetails Event { get; set; } = null!;

        public List<TicketGroupByTypeDetails> GroupByType { get; set; } = new List<TicketGroupByTypeDetails>();
    }
}
