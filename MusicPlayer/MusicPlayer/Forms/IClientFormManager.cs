using MusicPlayer.Ipc;

namespace MusicPlayer.Forms
{
    public interface IClientFormManager
    {
        IClientIPCManager ClientIPCManager { get; set; }
        IUserView MainForm { get; set; }
    }
}