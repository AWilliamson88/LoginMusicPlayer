using System;

namespace MusicPlayer.Ipc
{
    public interface IClientConnection
    {
        event EventHandler<byte[]> MessageReceived;
        event PipeClient.ServerDisconnectedHandler ServerDisconnected;

        void Connect(string pipename);
        void Disconnect();
        void Read();
        void SendMessage(string messageString);
    }
}