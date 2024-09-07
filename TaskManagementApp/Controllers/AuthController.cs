using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.DTO;
using TaskManagementApp.Interfaces.IServices;
using TaskManagementApp.Models;

namespace TaskManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;

        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("create-user", Name ="CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserRequestDTO request)
        {
            try
            {
                var userResult = await _authService.GetUserByEmail(request.Email);
                if (userResult.Status)
                {
                    return BadRequest(new GeneralResponseDTO(false, "User already exist"));
                }

                User user = new User();
                user.Id = Guid.NewGuid().ToString();
                user.UserName = request.UserName;
                user.Email = request.Email;
                user.Role = request.Role;
                user.Password = request.Password;

                var result = await _authService.CreateUser(user);
                if ( !result.Status )
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpPost("login", Name = "UserLogin")]
        public async Task<IActionResult> LoginUser([FromBody] UserLoginRequestDTO requset)
        {
            try
            {
                var userResult = await _authService.GetUserByEmail(requset.Email);
                if (!userResult.Status)
                {
                    return BadRequest(userResult);
                }

                var user = (User)userResult.Data;
                var authenticateUser = await _authService.AuthenticateUser(requset.Password, user.Password);
                if (!authenticateUser.Status)
                {
                    return BadRequest(authenticateUser);
                }

                var result = _jwtService.GenerateToken(user);

                return Ok(new GeneralResponseDTO(true, result));
            }
            catch (Exception ex)
            {
                return BadRequest(new GeneralResponseDTO(false, ex.Message));
            }
        }
    }
}
