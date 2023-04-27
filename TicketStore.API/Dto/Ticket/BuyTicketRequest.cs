using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto.Ticket
{
    public class BuyTicketRequest
    {
        [Required]
        public Guid? EventId { get; set; }

        [Required]
        public Guid? TicketTypeId { get; set; }
    }
}
