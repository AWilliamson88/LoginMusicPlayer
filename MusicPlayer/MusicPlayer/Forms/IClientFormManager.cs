using MusicPlayer.Ipc;
using System.Windows.Forms;

namespace MusicPlayer.Forms
{
    public interface IClientFormManager
    {
        IClientIPCManager ClientIPCManager { get; set; }
        IUserView MainForm { get; set; }
    }
}