using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketStore.Repository.Entities
{
    [Table("ticket_status")]
    public class DbTicketStatus
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; } = null!;

    }
}
