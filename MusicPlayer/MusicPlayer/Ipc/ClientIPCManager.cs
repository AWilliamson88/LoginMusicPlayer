namespace MusicPlayer.Ipc
{
    public class ClientIPCManager : IClientIPCManager
    {
        public IClientConnection Connection { get; }
        public IMessageProcessor MsgProccessor { get; }

        public ClientIPCManager(
            IClientConnection connection,
            IMessageProcessor msgProcessor)
        {
            Connection = connection;
            MsgProccessor = msgProcessor;

            Connection.MessageReceived += Connection_MessageReceived;
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
