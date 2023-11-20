using System.Security.Cryptography;
using System.Text;

namespace JwtToken2Project.Services
{
    public class Hash512
    {
        public static string ComputeHash512(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha512.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }
    }
}
