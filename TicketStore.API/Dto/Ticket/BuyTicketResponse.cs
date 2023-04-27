namespace TicketStore.API.Dto.Ticket
{
    public class BuyTicketResponse
    {
        public bool IsSuccess { get; set; }

        public string? Message { get; set; }

        public TicketDetails? Ticket { get; set; }

    }
}
