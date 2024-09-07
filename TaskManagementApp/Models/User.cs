using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementApp.Models
{
    public class User
    {
        [Key]
        [Column( "UserId", TypeName ="nvarchar(100)")]
        public string Id { get; set; }

        [Required]
        [Column( "UserName", TypeName ="nvarchar(100)")]
        public string UserName { get; set; }

        [Required]
        [Column("Email", TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Required]
        [Column("Role", TypeName = "nvarchar(20)")]
        public string Role { get; set; }

        [Required]
        [Column("Password", TypeName = "nvarchar(100)")]
        public string Password { get; set; }
    }
}
