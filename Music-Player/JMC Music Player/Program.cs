using MusicPlayer.Factories;
using MusicPlayer.Ipc;
using System;
using System.Windows.Forms;

/// <summary>
/// Author: Andrew Williamson
/// 
/// </summary>
namespace JMC_Music_Player
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            var factory = new ClientFactory();

            var client = new ClientIPCManager(
                factory.GetConnection(),
                factory.GetMessageProcessor());

            var view = new UserView();
            view.Presenter = factory.GetClientPresenter();

            var formManager = factory.GetClientFormManager(view, client);

            Application.Run(view);
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception ex = (Exception)args.ExceptionObject;

            string LF = Environment.NewLine + Environment.NewLine;
            string title = $"Oups... I got a crash at {DateTime.Now}";
            string infos = $"Please take a screenshot of this message\n\r\n\r" +
                           $"Message : {LF}{ex.Message}{LF}" +
                           $"Source : {LF}{ex.Source}{LF}" +
                           $"Stack : {LF}{ex.StackTrace}{LF}" +
                           $"InnerException : {ex.InnerException}";

            MessageBox.Show(infos, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
