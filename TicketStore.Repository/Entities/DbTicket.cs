using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketStore.Domain;

namespace TicketStore.Repository.Entities
{
    [Table("ticket")]
    public class DbTicket
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("price", TypeName = "NUMERIC")]
        [Required]
        public double Price { get; set; }

        [Column("is_available", TypeName = "BIT")]
        public bool IsAvailable { get; set; } = true;

        [ForeignKey("event_id")]
        public virtual DbEvent Event { get; set; } = null!;

        [ForeignKey("type_id")]
        public virtual DbTicketType Type { get; set; } = null!;

        [Column("status_id")]
        public int Status { get; set; }

    }
}
