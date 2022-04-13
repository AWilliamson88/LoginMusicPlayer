﻿using MusicPlayer.Factories;
using MusicPlayer.Ipc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.Forms
{
    public class ClientFormManager : IClientFormManager
    {
        public IClientIPCManager ClientIPCManager { get; set; }
        public IUserView MainForm { get; set; }
        public ClientFactory Factory { get; set; }

        public ClientFormManager(IUserView mainForm, IClientIPCManager clientIpcManager)
        {
            MainForm = mainForm;
            ClientIPCManager = clientIpcManager;

            MainForm.MessageToServer += SendMessage;
        }

        private void SendMessage(object sender, string message)
        {
            ClientIPCManager.SendMessage(message);
        }



    }
}