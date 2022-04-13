using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.Ipc
{
    public class MessageProcessor : IMessageProcessor
    {   
        private readonly IUser _user;

        public MessageProcessor(IUser user)
        {
            _user = user;
        }

        public void ProcessMessage(byte[] message)
        {
            if (message == null) return;

            string[] msg = Utility.ConvertToString(message);

            if (msg.Length == 0) return;

            if (msg[0] == "lo")
            {
                LoginResult(msg[1]);
                //return;
            }
            else if (msg[0] == "ce")
            {
                AccountCreationResult(msg[1]);
                //return;
            }

            //_user.OnStateChanged();

        }

        private void LoginResult(string result)
        {
            if (result.Equals("Yes"))
            {
                _user.CurrentState = User.State.LOGGED_IN;
            }
            else
            {
                _user.LastError = User.Error.FAILED_TO_LOGIN;
            }
        }

        private void AccountCreationResult(string result)
        {
            if (result.Equals("Yes"))
            {
                _user.CurrentState = User.State.ACCOUNT_CREATED;

                MessageBox.Show(
                    "Congratulations your account has been created.",
                    "Account Created",
                    MessageBoxButtons.OK
                    );
            }
            else
            {
                _user.LastError = User.Error.FAILED_TO_CREATE_ACCOUNT;
            }
        }
    }
}
