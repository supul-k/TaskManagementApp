using TaskManagementApp.DTO.Internal;
using TaskManagementApp.Models;

namespace TaskManagementApp.Interfaces.IServices
{
    public interface IAuthService
    {
        public Task<GeneralResponseInternalDTO> GetUserByEmail(string email);

        public Task<GeneralResponseInternalDTO> CreateUser(User user);

        public Task<GeneralResponseInternalDTO> AuthenticateUser(string requestPassword, string Password);
    }
}
