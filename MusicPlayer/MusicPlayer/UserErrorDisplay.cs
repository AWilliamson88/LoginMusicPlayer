using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public class UserErrorDisplay
    {
        private readonly User.Error _error;

        public UserErrorDisplay(User.Error error)
        {
            _error = error;
        }

        public void ShowError()
        {
            if (_error == User.Error.FAILED_TO_LOGIN)
            {
                ShowLoginError();
            }
            else if (_error == User.Error.FAILED_TO_CREATE_ACCOUNT)
            {
                ShowAccountCreationError();
            }

        }

        private void ShowAccountCreationError()
        {
            MessageBox.Show(
                    "Failed to create an account.\n" +
                    "An account with that name may already exists.",
                    "Account Name Invalid",
                    MessageBoxButtons.OK
                    );
        }

        private void ShowLoginError()
        {
            MessageBox.Show(
                "Username or Password incorrect.\n" +
                "Please try again.", 
                "Login Error", 
                MessageBoxButtons.OK
                );
        }
    }
}
