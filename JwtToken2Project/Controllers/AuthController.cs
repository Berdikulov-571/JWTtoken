using JwtToken2Project.Entities;
using JwtToken2Project.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtToken2Project.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;
        public AuthController(ITokenRepository tokenRepository,IUserRepository userRepository)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async ValueTask<IActionResult> LoginAsync(string userName, string password)
        {
            User user = await _userRepository.CheckLogin(userName, password);

            if (user != null)
            {
                string token = _tokenRepository.GenerateToken(user.UserName, user.Role);
                return Ok(token);
            }
            return NotFound("User Not Found");
        }
    }
}
