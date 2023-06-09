namespace TicketStore.API.Dto.Account
{
    public class AuthenticatedUser
    {
        public string? Username { get; set; }
        
        public string? Email { get; set; }
        
        public string? FullName { get; set; }

        public string? Token { get; set; }

        public ICollection<String> Roles { get; set; } = new List<String>();
    }
}
