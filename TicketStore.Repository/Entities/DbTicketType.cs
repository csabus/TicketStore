using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketStore.Repository.Entities
{
    [Table("ticket_type")]
    public class DbTicketType
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("name", TypeName = "nvarchar(100)")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("description", TypeName = "nvarchar(255)")]
        public string? Description { get; set; } = string.Empty;

        [ForeignKey("venu_id")]
        public virtual DbVenue Venue { get; set; } = null!;
    }
}
