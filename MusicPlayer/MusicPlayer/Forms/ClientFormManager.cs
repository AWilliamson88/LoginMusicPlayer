using MusicPlayer.Factories;
using MusicPlayer.Ipc;
using System;
using System.Windows.Forms;

namespace MusicPlayer.Forms
{
    public class ClientFormManager : IClientFormManager
    {
        public IClientIPCManager ClientIPCManager { get; set; }
        public IUserView MainForm { get; set; }

        public ClientFormManager(IUserView mainForm, IClientIPCManager clientIpcManager)
        {
            MainForm = mainForm;
            ClientIPCManager = clientIpcManager;

            MainForm.MessageToServer += SendMessage;
            clientIpcManager.ServerDisconnected += Ipc_Disconnected;
        }

        private void Ipc_Disconnected(object sender, EventArgs e)
        {
            MainForm.ServerDisconnected();
        }

        private void SendMessage(object sender, string message)
        {
            ClientIPCManager.SendMessage(message);
        }

    }
}
