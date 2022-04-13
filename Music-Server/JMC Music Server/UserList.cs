using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

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
    /// Question 3 
    /// Contains 3rd party library,
    /// Contains dynamic data structures.
    /// This class contains the data and methods for managing the list of uers.
    /// </summary>
    class UserList
    {
        /// <summary>
        /// Question 3 
        /// Contains dynamic data structures.
        /// The linked list for storing the list of users loaded from the csv.
        /// </summary>
        private LinkedList<User> users = new LinkedList<User>();

        public UserList()
        {
            GetUserList();
        }

        #region Load The User List
        /// <summary>
        /// Question 3
        /// Contains 3rd party library.
        /// This method loads the user list read from the csv file and
        /// stores it in a linked list.
        /// </summary>
        private void GetUserList()
        {
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                    //HasHeaderRecord = false,
                };
                using (var reader = new StreamReader(@"..\..\..\Users\UserList.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        users.Clear();
                        csv.Read();
                        csv.ReadHeader();

                        var records = csv.GetRecords<User>();
                        foreach (var u in records)
                        {
                            users.AddLast(u);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ////Console.Out.WriteLine("Error while reading user list.");
                //Console.Out.WriteLine("Could not find list of users.");
                Console.Out.WriteLine(e.Message);
            }
        }
        #endregion

        #region Saves The User List
        /// <summary>
        /// Question 3
        /// Contains 3rd party library
        /// Saves the list of users from the linked list into a csv file 
        /// using CsvHelper.
        /// </summary>
        public void SaveUserList()
        {
            try
            {
                if (!Directory.Exists(@"..\..\..\Users"))
                {
                    Directory.CreateDirectory(@"..\..\..\Users");
                }
                if (!File.Exists(@"..\..\..\Users\UserList.csv"))
                {
                    File.Create(@"..\..\..\Users\UserList.csv");
                }
                using (var writer = new StreamWriter(@"..\..\..\Users\UserList.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(users);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while saving user list.");
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Checks if the given username exists in the list.
        /// </summary>
        /// <param name="userName">The user name to search the list for.</param>
        /// <returns>True if the username is in the list, otherwise false.</returns>
        public bool CheckList(string userName)
        {
            foreach (User u in users)
            {
                if (u.UserName.Equals(userName))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets the users password hash.
        /// </summary>
        /// <param name="userName">The user whose password hash to get.</param>
        /// <returns>the users password hash if the user is in the list,
        /// otherwise string.empty.</returns>
        public string GetUserHash(string userName)
        {
            foreach (User u in users)
            {
                if (u.UserName.Equals(userName))
                {
                    return u.PasswordHash;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Adds a new user with the given username and password into the list.
        /// </summary>
        /// <param name="userName">The new users username.</param>
        /// <param name="password">The new users password.</param>
        public void AddUser(string userName, string password)
        {
            users.AddLast(new User(userName, password));
        }
        #endregion
    }

}
