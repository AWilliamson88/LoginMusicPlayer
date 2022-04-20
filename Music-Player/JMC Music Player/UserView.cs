using JMC_Music_Player.GUI;
using MusicPlayer;
using MusicPlayer.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// Author: Andrew Williamson 
/// 
/// </summary>
namespace JMC_Music_Player
{
    public partial class UserView : Form, IUserView
    {
        /// <summary>
        /// The side menu button that is currently active.
        /// </summary>
        private Button CurrentButton { get; set; }
        /// <summary>
        /// The child form that is currently active.
        /// </summary>
        //private new IChildForm ActiveForm { get; set; }
        private new Form ActiveForm { get; set; }
        private LoginForm LgnFrm { get; set; }
        private CreateAccountForm CreateAccForm { get; set; }
        public IClientPresenter Presenter { get; set; }
        private readonly User user = User.GetUser();

        public event EventHandler<string> MessageToServer = delegate { };

        public delegate void StateChanged(string userName, User.State state);
        public StateChanged stateChangedDelegate;
        public delegate void UserError(string userName, User.Error error);


        public UserView()
        {
            InitializeComponent();
        }

        #region ProgramStartAndCloseMethods
        /// <summary>
        /// Opens the login form and attaches the event listeners.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserView_Load(object sender, EventArgs e)
        {
            LgnFrm = new LoginForm();
            OpenChildForm(LgnFrm, LoginBtn);
            LgnFrm.SendMessage += MessageFromForm;

            user.StateChanged += User_StateChanged;
            user.UserError += User_Error;
        }


        /// <summary>
        /// When the program is closing disconnect the listeners and close the active form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserView_FormClosing(object sender, EventArgs e)
        {
            CloseActiveForm();
            user.StateChanged -= User_StateChanged;
            user.UserError -= User_Error;
        }

        private void CloseActiveForm()
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
        }
        #endregion

        #region FormDisplay
        private void User_StateChanged(object sender, User.State state)
        {
            Invoke(new StateChanged(UserStateChanged), new object[] { sender, state });
        }

        private void UserStateChanged(string userName, User.State state)
        {
            Presenter.UpdateMenuHeader(MenuHeaderLbl, userName);

            UpdateTheForm(state);
        }

        /// <summary>
        /// Sets the usability of the buttons depending on the user logged in state 
        /// and switches to the music player form upon successfully logging in.
        /// </summary>
        public void UpdateTheForm(User.State state)
        {
            if (state == User.State.LOGGED_IN)
            {
                UpdateMenuUserLoggedIn();
                OpenChildForm(new MusicPlayerForm(), MusicPlayerBtn);
            }

            if (state == User.State.NOT_LOGGED_IN)
                UpdateMenuUserLoggedOut();
        }

        private void UpdateMenuUserLoggedIn()
        {
            Presenter.RemoveButtons(
                new List<Button> {
                    CreateAccBtn,
                    LoginBtn
                }
            );

            Presenter.RestoreButton(MusicPlayerBtn);
        }

        private void UpdateMenuUserLoggedOut()
        {
            Presenter.RestoreButtons(
                new List<Button> {
                    CreateAccBtn,
                    LoginBtn
                });
        }

        #endregion

        #region User Errors
        private void User_Error(object sender, User.Error error)
        {
            Invoke(new UserError(DisplayError), new object[] { sender, error });
        }

        private void DisplayError(object sender, User.Error error)
        {
            UserErrorDisplay ued = new UserErrorDisplay(error);
            ued.ShowError();
        }

        #endregion

        #region ServerDisconnected
        //private void pipeClient_ServerDisconnected()
        //{
        //    Invoke(new PipeClient.ServerDisconnectedHandler(ServerDisconnected));
        //}

        /// <summary>
        /// updates the form and removes the event listeners.
        /// </summary>
        //private void ServerDisconnected()
        //{
        //    //UpdateTheForm();
        //    Removelisteners();
        //    //ClosePipeClient();
        //    //SetupPipeClient();
        //}
        #endregion


        // Methods relatinng to the side panel menu buttons and their forms.
        #region ChildFormMethods
        /// <summary>
        /// This method takes a child form and a button, makes the form the new active form and
        /// activates it's button on the side menu.
        /// </summary>
        /// <param name="childForm">The new active child form.</param>
        /// <param name="btnSender">The button to make the new current active button.</param>
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (ActiveForm != null)
                ActiveForm.Close();

            if (CurrentButton != null)
            {
                Presenter.ResetButtonStyles(CurrentButton);
            }
            CurrentButton = (Button)btnSender;

            Presenter.ActivateButton((Button)btnSender);
            Presenter.UpdateTitle(TitleLbl, childForm.Text);
            Presenter.ShowFormInPanel(DesktopPanel, childForm);
            //ActiveForm = (IChildForm)childForm;
            ActiveForm = childForm;
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (ActiveForm.GetType() == typeof(LoginForm))
                return;

            LgnFrm = new LoginForm();
            Removelisteners();
            OpenChildForm(LgnFrm, sender);
            LgnFrm.SendMessage += new EventHandler<string>(MessageFromForm);
        }

        private void CreateAccBtn_Click(object sender, EventArgs e)
        {
            if (ActiveForm.GetType() == typeof(CreateAccountForm))
                return;

            CreateAccForm = new CreateAccountForm();
            Removelisteners();
            OpenChildForm(CreateAccForm, sender);
            CreateAccForm.SendMessage += new EventHandler<string>(MessageFromForm);
        }
        #endregion

        #region ChildFormMessageMethods
        /// <summary>
        /// Used to remove the listener attached to the child form.
        /// </summary>
        private void Removelisteners()
        {
            if (ActiveForm.GetType() == typeof(CreateAccountForm))
                CreateAccForm.SendMessage -= MessageFromForm;

            if (ActiveForm.GetType() == typeof(LoginForm))
                LgnFrm.SendMessage -= MessageFromForm;
        }

        /// <summary>
        /// This method receives the messages from the active form
        /// and calls the MessageFromForm event.
        /// </summary>
        /// <param name="form">The form the message came from.</param>
        /// <param name="message">The message to be sent to the server.</param>
        private void MessageFromForm(object form, string message)
        {
            MessageToServer?.Invoke(form, message);
        }

        #endregion

    }
}
