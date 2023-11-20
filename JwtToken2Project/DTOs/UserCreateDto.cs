using JwtToken2Project.Enums;

namespace JwtToken2Project.DTOs
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
