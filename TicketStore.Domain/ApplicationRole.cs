namespace TicketStore.Domain
{
    public class ApplicationRole
    {
        public Guid ApplicationRoleId { get; set; }

        public string? Name { get; set; }

        public string? NormalizedName { get; set; }
        
        public string? Description { get; set; }
    }
}
