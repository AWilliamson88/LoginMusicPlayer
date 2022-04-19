namespace MusicPlayer.Ipc
{
    public interface IClientIPCManager
    {
        IClientConnection Connection { get; }
        IMessageProcessor MsgProccessor { get; }
        void SendMessage(string message);
    }
}