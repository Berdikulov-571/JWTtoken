using JWTtoken.Entities;
using JWTtoken.Models;
using JWTtoken.Services.Auth;
using JWTtoken.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace JWTtoken.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginRequest request)
        {
            IEnumerable<Users> users = await _userService.GetAllUsersAsync();

            Users? user = users.FirstOrDefault(x => x.UserName == request.UserName && x.PasswordHash == request.Password);

            if (user == null)
                return NotFound("Login yo password hato");

            string token = _authService.GenerateToken(request.UserName);

            return Ok(token);
        }
    }
}
