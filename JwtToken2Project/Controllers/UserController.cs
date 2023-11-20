using JwtToken2Project.DTOs;
using JwtToken2Project.Entities;
using JwtToken2Project.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtToken2Project.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync(UserCreateDto model)
        {
            await _userRepository.CreateAsync(model);

            return Ok("Sucesfully");
        }

        [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            IEnumerable<User> users = await _userRepository.GetAllAsync();

            return Ok(users);
        }
    }
}
