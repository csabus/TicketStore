using TicketStore.Domain.Enum;

namespace TicketStore.Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public double Price { get; set; }

        public bool IsAvailable { get; set; } = true;

        public Event Event { get; set; } = null!;

        public TicketType Type { get; set; } = null!;

        public TicketStatus Status { get; set; }

    }
}
