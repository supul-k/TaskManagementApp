using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.DTO
{
    public class AssignmentRequestDTO
    {

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
