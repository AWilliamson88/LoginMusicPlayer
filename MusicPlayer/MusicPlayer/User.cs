using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class User : IUser
    {
        public enum State
        {
            NOT_LOGGED_IN,
            LOGGED_IN,
            ACCOUNT_CREATED,
        }

        public enum Error
        {
            FAILED_TO_LOGIN,
            FAILED_TO_CREATE_ACCOUNT
        }

        private static readonly User _user = new User();
        public string UserName { get; set; } = "Anonymous";
        private State state;
        public event EventHandler<State> StateChanged;
        private Error error;
        public event EventHandler<Error> UserError;

        private User() { }

        public State CurrentState
        {
            get { return state; }
            set
            {
                state = value;
                OnStateChanged();
            }
        }

        public Error LastError
        {
            get { return error; }
            set
            {
                error = value;
                OnErrorOccured();
            }
        }

        protected virtual void OnStateChanged()
        {
            EventHandler<State> handler = StateChanged;
            //StateChanged?.Invoke(UserName, CurrentState);
            handler?.Invoke(UserName, CurrentState);
        }

        protected virtual void OnErrorOccured()
        {
            EventHandler<Error> handler = UserError;
            handler?.Invoke(UserName, LastError);
        }

        public static User GetUser() => _user;

    }
}
