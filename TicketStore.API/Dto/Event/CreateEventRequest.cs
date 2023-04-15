using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto.Event
{
    public class CreateEventRequest
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public Guid VenueId { get; set; }

    }
}
