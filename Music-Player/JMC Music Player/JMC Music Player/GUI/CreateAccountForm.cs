using System;
using System.Windows.Forms;
using static Music_Player.GUI.UserDetailsProcessor;

/// <summary>
/// Author: Andrew Williamson
/// 
/// </summary>
namespace Music_Player.GUI
{
    public partial class CreateAccountForm : Form, IChildForm
    {
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler to send a string message from the create account form
        /// to the main form.
        /// </summary>
        public event EventHandler<string> SendMessage;

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            //AcceptButton = CreateAccountBtn;
            UsernameTB.Focus();
        }

        #region Click&KeyPress
        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            AttemptAccountCreation();
        }

        private void PasswordTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            // if the enter key is pressed try to create a new account.
            if (e.KeyChar == (char)Keys.Enter)
            {
                AttemptAccountCreation();
            }
        }
        #endregion

        #region AttemptToCreateAccount
        /// <summary>
        /// If the username and password textboxes have text this method will send 
        /// the relevant string to the main form to be sent to the server for processing.
        /// </summary>
        private void AttemptAccountCreation()
        {
            if (string.IsNullOrEmpty(UsernameTB.Text) ||
                string.IsNullOrEmpty(PasswordTB.Text))
            {
                MessageBox.Show("Username and Password required.", "Account Error", MessageBoxButtons.OK);
                return;
            }

            string AccountCreationDetails = "ce," + ProcessUserDetails(UsernameTB.Text.Trim(), PasswordTB.Text.Trim());
            SendToUserView(AccountCreationDetails);
            ClearUserDetails();
        }

        /// <summary>
        /// Invokes the CreateAccountMessage event and sends the message to the main form.
        /// </summary>
        /// <param name="message">The string containing the message</param>
        public void SendToUserView(string message)
        {
            SendMessage?.Invoke(this, message);
        }
        #endregion

        /// <summary>
        /// Clears the username and password text boxes.
        /// </summary>
        private void ClearUserDetails()
        {
            UsernameTB.Clear();
            PasswordTB.Clear();
        }

    }
}
