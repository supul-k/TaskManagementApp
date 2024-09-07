using Microsoft.EntityFrameworkCore;
using TaskManagementApp.DatabaseAccess;
using TaskManagementApp.DTO.Internal;
using TaskManagementApp.Interfaces.IRepositories;
using TaskManagementApp.Models;

namespace TaskManagementApp.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponseInternalDTO> CreateUser(User user)
        {
            try
            {
                _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return new GeneralResponseInternalDTO(true, "User created");
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
                var result = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (result == null)
                {
                    return new GeneralResponseInternalDTO(false, "Users not found");
                }
                return new GeneralResponseInternalDTO(true, "User found", result);
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
