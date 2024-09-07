using TaskManagementApp.DTO.Internal;
using TaskManagementApp.Interfaces.IRepositories;
using TaskManagementApp.Interfaces.IServices;
using TaskManagementApp.Models;

namespace TaskManagementApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<GeneralResponseInternalDTO> CreateUser(User user)
        {
            try
            {
                var result = await _authRepository.CreateUser(user);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> GetUserByEmail(string email)
        {
            try
            {
                var result = await _authRepository.GetUserByEmail(email);
                return result;
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }

        public async Task<GeneralResponseInternalDTO> AuthenticateUser(string requestPassword, string Password)
        {
            try
            {
                if ( requestPassword != Password)
                {
                    return new GeneralResponseInternalDTO(false, "Incorrect password");
                }
                return new GeneralResponseInternalDTO(true, "Password correct");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
