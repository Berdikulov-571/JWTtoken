using JWTtoken.Models;
using JWTtoken.Services.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ADars1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserCreateDto userModel)
        {
            // bu malumotlar
            var claims = new Claim[]
            {
                // name 
                new Claim("UserName", userModel.UserName),
                // identificatori
                new Claim("Password",userModel.Password),
                // vaqti
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),

            };

            // qandedur algoritm boyicha shifrlanadi
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                _configuration["JWT:ValidIssuer"],
                _configuration["JWT:ValidAudience"],
                claims,
                expires: DateTime.Now.AddSeconds(3),
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);

        }
    }
}