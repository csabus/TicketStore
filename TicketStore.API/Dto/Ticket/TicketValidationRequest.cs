using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto.Ticket
{
    public class TicketValidationRequest
    {
        [Required]
        public Guid? TicketId { get; set; }

        [Required]
        public Guid? EventId { get; set; }
    }
}
