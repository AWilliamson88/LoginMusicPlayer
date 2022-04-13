using System;
using System.Security.Cryptography;
using System.Text;

namespace Music_Player.GUI
{
    static class PasswordProcessor
    {
        public static string GeneratePasswordHash(string password)
        {
            // Use SHA512 to generate the hash from the password
            SHA512 sha = new SHA512CryptoServiceProvider();

            byte[] dataBytes = Encoding.UTF8.GetBytes(password);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            return BitConverter.ToString(resultBytes).Replace("-", String.Empty);
        }
    }
}
