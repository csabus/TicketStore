using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketStore.Repository.Entities
{
    [Owned]
    public class DbAddress
    {
        [Column("address_country", TypeName = "varchar(50)")]
        [Required]
        public string Country { get; set; } = null!;

        [Column("address_zip_code", TypeName = "varchar(10)")]
        [Required]
        public string ZipCode { get; set; } = null!;

        [Column("address_city", TypeName = "varchar(100)")]
        [Required]
        public string City { get; set; } = null!;

        [Column("address_street", TypeName = "varchar(150)")]
        [Required]
        public string Street { get; set; } = null!;

    }
}
