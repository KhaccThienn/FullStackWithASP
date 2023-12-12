using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_WebAPI.Models
{
    [Table("People")]
    public class People
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [StringLength(150)]
        public string LastName { get; set; }

        [Column]
        public bool Gender { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [StringLength(250)]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string Province { get; set; }
    }
}
