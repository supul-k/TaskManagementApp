using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.DTO
{
    public class UserRequestDTO
    { 
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }
    }
}
