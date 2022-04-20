using System;

namespace MusicPlayer.Ipc
{
    public class ClientIPCManager : IClientIPCManager
    {
        public IClientConnection Connection { get; }
        public IMessageProcessor MsgProccessor { get; }
        public event EventHandler ServerDisconnected;

        public ClientIPCManager(
            IClientConnection connection,
            IMessageProcessor msgProcessor)
        {
            Connection = connection;
            MsgProccessor = msgProcessor;

            Connection.MessageReceived += Connection_MessageReceived;
            Connection.ServerDisconnected += Connection_ServerDisconnected;
        }

        private void Connection_ServerDisconnected()
        {
            ServerDisconnected?.Invoke(this, EventArgs.Empty);
        }

        private void Connection_MessageReceived(object sender, byte[] message)
        {
            MsgProccessor.ProcessMessage(message);
        }

        public void SendMessage(string message)
        {
            Connection.SendMessage(message);
        }

    }
}
