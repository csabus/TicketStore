namespace TicketStore.Domain
{
    public class ApplicationUser
    {
        public Guid ApplicationUserId { get; set; }

        public string? Username { get; set; }

        public string? NormalizedUsername { get; set; }

        public string? Email { get; set; }

        public string? NormalizedEmail { get; set; }

        public string? Fullname { get; set; }

        public string? PasswordHash { get; set; }

    }
}