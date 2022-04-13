using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Author: Andrew Williamson / P113357
/// Programming III
/// Assessment Tast 3
/// Question 3 - Implement your solution
/// 
/// - Must contain dynamic data structures
/// - Must contain hashing techniques
/// - Must contain sorting algorithm
/// - Must contain searching technique
/// - Must contain 3rd party library
/// - Must have a GUI
/// - Must adhere to coding standards
/// </summary>
namespace JMC_Music_Server
{
    /// <summary>
    /// This class is responsible for processing the password hashes.
    /// </summary>
    class PasswordProcessor
    {
        /// <summary>
        /// Question 3
        /// Contains hashing techniques.
        /// Hashes the password
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hashed password.</returns>
        public string GeneratePasswordHash(string password)
        {
            string str = password;

            // Use SHA512 to generate the hash from the password
            SHA512 sha = new SHA512CryptoServiceProvider();

            byte[] dataBytes = Encoding.UTF8.GetBytes(str);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            //Console.WriteLine("Utility.ConvertToString " + Utility.ConvertToString(resultBytes));
            //Console.WriteLine("Encoding.UTF8.GetString " + Encoding.UTF8.GetString(resultBytes));
            //Console.WriteLine("BitConverter.ToString " + BitConverter.ToString(resultBytes).Replace("-", String.Empty));
            return BitConverter.ToString(resultBytes).Replace("-", String.Empty);
        }

    }
}
