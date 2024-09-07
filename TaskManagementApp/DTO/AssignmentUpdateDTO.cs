using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.DTO
{
    public class AssignmentUpdateDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool Status { get; set; }
    }
}
