using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementApp.Models
{
    public class Assignment
    {
        [Key]
        [Column("TaskId", TypeName = "nvarchar(100)")]
        public string Id { get; set; }

        [Required]
        [Column("Title", TypeName = "nvarchar(100)")]
        public string Title { get; set; }

        [Column("Description", TypeName = "nvarchar(450)")]
        public string Description { get; set; }

        [Required]
        [Column("DueDate")]
        public DateTime DueDate { get; set; }

        [Required]
        [Column("Status")]
        public bool Status { get; set; }
    }
}
