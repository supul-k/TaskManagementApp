using TaskManagementApp.Models;

namespace TaskManagementApp.Interfaces.IServices
{
    public interface IJwtService
    {
        public string GenerateToken(User user);
    }
}
