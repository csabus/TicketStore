using TicketStore.API.Dto.Event;

namespace TicketStore.API.Dto.Ticket
{
    public class TicketDetails
    {
        public Guid Id { get; set; }

        public double Price { get; set; }

        public bool IsAvailable { get; set; } = true;

        public EventDetails Event { get; set; } = null!;

        public TicketTypeDetails Type { get; set; } = null!;

        public int Status { get; set; }
    }
}
