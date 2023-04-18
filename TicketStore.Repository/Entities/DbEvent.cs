using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketStore.Repository.Entities
{
    [Table("event")]
    public class DbEvent
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title", TypeName = "nvarchar(150)")]
        [Required]
        public string Title { get; set; } = null!;

        [Column("description", TypeName = "nvarchar(max)")]
        [Required]
        public string Description { get; set; } = null!;

        [Column("date_time")]
        [Required]
        public DateTime DateTime { get; set; }

        [ForeignKey("venue_id")] 
        public DbVenue Venue { get; set; } = null!;

    }
}
