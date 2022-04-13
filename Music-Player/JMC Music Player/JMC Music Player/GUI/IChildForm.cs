using System;

namespace Music_Player.GUI
{
    internal interface IChildForm
    {
        event EventHandler<string> SendMessage;
        void SendToUserView(string message);
        void Close();
    }
}
