
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
    /// This class creates instances of the PasswordProcessor and PasswordTester classes
    /// and uses them to process the client login and account creation details.
    /// </summary>
    class ServerMessageProcessor
    {
        /// <summary>
        /// An instance of the UserList class that holds the list of users and related methods.
        /// </summary>
        private readonly UserList ul;

        public ServerMessageProcessor(UserList userList)
        {
            ul = userList;
        }

        /// <summary>
        /// Question 3 
        /// Contains hashing techniques.
        /// Takes the client message and processes it using instances of the PasswordProcessor
        /// and PasswordTester classes that use hashing techniques.
        /// </summary>
        /// <param name="clientMessage">The byte[] message from the client.</param>
        /// <returns>Returns "Yes" if the clients username and password match the username and
        /// password saved in the user list. Otherwise "No".</returns>
        public string LoginResultProcessor(string[] clientMessage)
        {
            if (ul.CheckList(clientMessage[1]))
            {
                PasswordProcessor pp = new PasswordProcessor();
                string clientPasswordHash = pp.GeneratePasswordHash(clientMessage[2] + clientMessage[1]);
                string userHash = ul.GetUserHash(clientMessage[1]);

                PasswordTester pt = new PasswordTester();
                if (pt.TestPasswords(userHash, clientPasswordHash))
                    return "Yes," + clientMessage[1];
            }
            return "No";
        }

        /// <summary>
        /// Question 3 
        /// Contains hashing techniques.
        /// Takes in the client's account creation request and checks if an account by that name
        /// already exists. If not it creates the new account with the username and password the 
        /// client specified using the hashing techniques in the PasswordProcessor class instance.
        /// </summary>
        /// <param name="clientMessage">The byte[] message from the client.</param>
        /// <returns>Returns "Yes" if the account was created successfully otherwise "No".</returns>
        public string AccountCreationResultProcessor(string[] clientMessage)
        {
            if (ul.CheckList(clientMessage[1]))
            {
                return "No";
            }
            PasswordProcessor pp = new PasswordProcessor();
            string passwordHash = pp.GeneratePasswordHash(clientMessage[2] + clientMessage[1]);
            //Console.WriteLine("New account password hash: " + passwordHash);

            ul.AddUser(clientMessage[1], passwordHash);
            return "Yes";
        }

    }
}
