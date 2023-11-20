using JwtToken2Project.Enums;

namespace JwtToken2Project.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
    }
}