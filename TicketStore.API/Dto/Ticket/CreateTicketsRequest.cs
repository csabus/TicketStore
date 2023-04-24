using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto.Ticket
{
    public class CreateTicketsRequest
    {
        [Required]
        public Guid? EventId { get; set; }

        [Required]
        public Guid? TicketTypeId { get; set; }

        [Required]
        public double? Price { get; set; }

        public bool? IsAvailable { get; set; } = true;

        public string? Status { get; set; }

        [Range(1, 5000)]
        public int? Count { get; set; } = 1;

    }
}
