using System;

namespace MusicPlayer.Forms
{
    public interface IUserView
    {
        event EventHandler<string> MessageToServer;
        void UpdateTheForm(User.State state);
        void ServerDisconnected();
    }
}
