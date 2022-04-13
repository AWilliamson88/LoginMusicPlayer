using CsvHelper.Configuration.Attributes;

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
    /// This class contains the user's details and is used by 
    /// the 3rd party library CsvHelper
    /// </summary>
    public class User
    {
        /// <summary>
        /// The username of the user.
        /// First column in csv file with column header "userName"
        /// </summary>
        [Index(0)]
        [Name("userName")]
        public string UserName { get; set; }

        /// <summary>
        /// The password Hash  of the User.
        /// Second column in csv file with column header "passwordHash"
        /// </summary>
        [Index(1)]
        [Name("passwordHash")]
        public string PasswordHash { get; set; }

        public User(string userName, string passwordHash)
        {
            UserName = userName;
            PasswordHash = passwordHash;
        }
    }
}
