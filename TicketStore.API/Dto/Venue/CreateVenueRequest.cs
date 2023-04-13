using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto.Venue
{
    public class CreateVenueRequest
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public AddressDTO Address { get; set; } = null!;
    }
}
