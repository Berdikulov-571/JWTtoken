using JWTtoken.Entities;
using JWTtoken.Models;
using JWTtoken.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTtoken.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsyncForAdmin()
        {
            try
            {
                IEnumerable<Users> users = await _userService.GetAllUsersAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound("Users not Found");
            }
        }

        [Authorize(Roles = "Developer")]
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsyncForDeveloper()
        {
            try
            {
                IEnumerable<Users> users = await _userService.GetAllUsersAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return NotFound("Users not Found");
            }
        }

        [HttpPost]
        public async ValueTask<IActionResult> PostAsync([FromForm]UserCreateDto createDTO)
        {
            bool res = await _userService.CreateAsync(createDTO);

            if(res)
                return Ok("Sucesfully");
            return BadRequest("Do Not Created");
        }
    }
}
