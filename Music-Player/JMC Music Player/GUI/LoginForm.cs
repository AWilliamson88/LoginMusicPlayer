using System;
using System.Windows.Forms;

/// <summary>
/// Author: Andrew Williamson
/// 
/// </summary>
namespace JMC_Music_Player.GUI
{
    public partial class LoginForm : Form, IChildForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler to send a string message from the login form
        /// to the main form.
        /// </summary>
        public event EventHandler<string> SendMessage;

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.AcceptButton = LoginBtn;
            UsernameTB.Focus();
        }

        #region Click&KeyPress
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        private void PasswordTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AttemptLogin();
            }
        }
        #endregion

        #region  AttemptToLogin
        /// <summary>
        /// If the username and password textboxes have text this method will send 
        /// the relevant string to the main form to be sent to the server for processing.
        /// </summary>
        private void AttemptLogin()
        {
            if (!string.IsNullOrEmpty(UsernameTB.Text) &&
                !string.IsNullOrEmpty(PasswordTB.Text))
            {
                string loginDetails = "lo," + UsernameTB.Text.Trim() + "," + PasswordTB.Text.Trim();
                SendToUserView(loginDetails);
                ClearUserDetails();
            }
            else
            {
                MessageBox.Show("Username and Password required.", "Login Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Invokes the LoginMessage event and sends the message to the main form.
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
            UsernameTB.Focus();
        }

    }
}
