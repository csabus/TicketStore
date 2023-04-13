using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto
{
    public class AddressDTO
    {
        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string ZipCode { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string Street { get; set; } = null!;
    }
}
