using System;

namespace MusicPlayer.Ipc
{
    public interface IClientIPCManager
    {
        IClientConnection Connection { get; }
        IMessageProcessor MsgProccessor { get; }
        event EventHandler ServerDisconnected;
        void SendMessage(string message);
    }
}