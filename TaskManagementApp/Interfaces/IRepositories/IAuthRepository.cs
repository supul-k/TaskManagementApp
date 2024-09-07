using TaskManagementApp.DTO.Internal;
using TaskManagementApp.Models;

namespace TaskManagementApp.Interfaces.IRepositories
{
    public interface IAuthRepository
    {
        public Task<GeneralResponseInternalDTO> GetUserByEmail(string email);

        public Task<GeneralResponseInternalDTO> CreateUser(User user);
    }
}
