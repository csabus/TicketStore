using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto.Venue
{
    public class UpdateVenueRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public AddressDTO Address { get; set; } = null!;
    }
}
