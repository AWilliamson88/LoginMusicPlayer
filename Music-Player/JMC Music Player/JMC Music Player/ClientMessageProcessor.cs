using System.Windows.Forms;

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
namespace JMC_Music_Player
{
    /// <summary>
    /// This class processes the messages that are returned from the server.
    /// </summary>
    class ClientMessageProcessor
    {
        /// <summary>
        /// Processes the returned login messages.
        /// </summary>
        /// <param name="result">The message from the server.</param>
        /// <returns>true if the server replied "Yes" otherwise creates an error message 
        /// message box and returns false.</returns>
        public bool LoginResultProcessor(string result)
        {
            if (result.Equals("Yes"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Username or Password incorrect.\nPlease try again.", "Login Error", MessageBoxButtons.OK);
                return false;
            }
        }

        /// <summary>
        /// Processes the returned account creation messages.
        /// Creates a popup window stating the result and returns a boolean.
        /// </summary>
        /// <param name="result">The message from the server.</param>
        /// <returns>true if the server replied "Yes" otherwise false.</returns>
        public bool AccountCreationResultProcessor(string result)
        {
            if (result.Equals("Yes"))
            {
                MessageBox.Show(
                    "Congratulations your account has been created.", 
                    "Account Created", 
                    MessageBoxButtons.OK
                    );
                return true;
            }
            else
            {
                MessageBox.Show(
                    "An account with that name already exists.", 
                    "Account Name Invalid", 
                    MessageBoxButtons.OK
                    );
                return false;
            }
        }

    }

}
