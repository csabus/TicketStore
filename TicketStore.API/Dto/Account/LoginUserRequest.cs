using System.ComponentModel.DataAnnotations;

namespace TicketStore.API.Dto.Account
{
    public class LoginUserRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
