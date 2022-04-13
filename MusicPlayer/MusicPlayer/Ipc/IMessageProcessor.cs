namespace MusicPlayer.Ipc
{
    public interface IMessageProcessor
    {
        void ProcessMessage(byte[] message);
    }
}