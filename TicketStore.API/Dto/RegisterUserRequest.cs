using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto
{
    public class RegisterUserRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Fullname { get; set; }

        [Required]
        public string? Password { get; set; }

    }
}
