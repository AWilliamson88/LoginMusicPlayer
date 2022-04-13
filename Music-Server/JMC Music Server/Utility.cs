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
    /// Contains utility methods that are used multiple times 
    /// within the program.
    /// </summary>
    class Utility
    {
        /// <summary>
        /// Used for messaging with the clients.
        /// Converts a string to a byte[].
        /// </summary>
        /// <param name="str">the string to convert.</param>
        /// <returns>The byte[]</returns>
        public static byte[] ConvertToBytes(string str)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] array = encoder.GetBytes(str);
            return array;
        }

        /// <summary>
        /// Used for messaging with the clients.
        /// Converts a byte[] to a string.
        /// </summary>
        /// <param name="array">The byte array to convert.</param>
        /// <returns>The string.</returns>
        public static string ConvertToString(byte[] array)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(array, 0, array.Length);
            return str;
        }
    }
}
