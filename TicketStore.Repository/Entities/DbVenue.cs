using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketStore.Repository.Entities
{
    [Table("venue")]
    public class DbVenue
    {

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name", TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; } = null!;

        [Column("description", TypeName = "varchar(255)")]
        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public DbAddress Address { get; set; } = null!;

        public virtual ICollection<DbEvent> Events { get; set; }

        public DbVenue()
        {
            Events = new HashSet<DbEvent>(); ;
        }
    }
}
