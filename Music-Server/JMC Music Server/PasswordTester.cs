
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
    /// This class is responsible for testing if the clients password matches the user password.
    /// </summary>
    class PasswordTester
    {
        /// <summary>
        /// Tests the user and client passwords to see if they match.
        /// </summary>
        /// <param name="userPassword">The user password.</param>
        /// <param name="clientPassword">The password to test.</param>
        /// <returns>True only if they match, otherwise false.</returns>
        public bool TestPasswords(string userPassword, string clientPassword)
        {
            if (userPassword.Equals(clientPassword))
            {
                return true;
            }
            return false;
        }

    }
}
