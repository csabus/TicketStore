using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketStore.Repository.Entities
{
    [Table("application_role")]
    public class DbApplicationRole
    {
        [Key]
        [Column("id")]
        public Guid ApplicationRoleId { get; set; }

        [Column("name", TypeName = "nvarchar(50)")]
        [Required]
        public string? Name { get; set; }

        [Column("normalized_name", TypeName = "nvarchar(50)")]
        [Required]
        public string? NormalizedName { get; set; }

        [Column("description", TypeName = "nvarchar(100)")]
        public string? Description { get; set; }

        [ForeignKey("role_id")]
        public virtual ICollection<DbApplicationUser> Users { get; set; }

        public DbApplicationRole()
        {
            Users = new HashSet<DbApplicationUser>();
        }
    }
}
