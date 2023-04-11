using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketStore.Repository.Entities
{
    [Table("application_user")]
    public class DbApplicationUser
    {
        [Key]
        [Column("id")]
        public Guid ApplicationUserId { get; set; }

        [Column("username", TypeName ="varchar(50)")]
        [Required]
        public string? Username { get; set; }

        [Column("normalized_username", TypeName ="varchar(50)")]
        [Required]
        public string? NormalizedUsername { get; set; }

        [Column("email", TypeName = "varchar(50)")]
        [Required]
        public string? Email { get; set; }

        [Column("normalized_email", TypeName = "varchar(50)")]
        [Required]
        public string? NormalizedEmail { get; set; }

        [Column("fullname", TypeName = "varchar(50)")]
        [Required]
        public string? Fullname { get; set; }

        [Column("password_hash", TypeName = "nvarchar(max)")]
        [Required]
        public string? PasswordHash { get; set; }

        [ForeignKey("user_id")]
        public virtual ICollection<DbApplicationRole> Roles { get; set; }

        public DbApplicationUser()
        {
            this.Roles = new HashSet<DbApplicationRole>();
        }
    }
}
