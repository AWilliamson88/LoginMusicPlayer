using MusicPlayer;
using MusicPlayer.Forms;
using MusicPlayer.Ipc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.Factories
{
    public class ClientFactory
    {
        public IClientConnection GetConnection() => 
            PipeClient.GetPipeClient();

        public IClientFormManager GetClientFormManager(
            IUserView mainForm, IClientIPCManager clientIpcManager) =>
                new ClientFormManager(mainForm, clientIpcManager);

        public IMessageProcessor GetMessageProcessor() =>
            new MessageProcessor(User.GetUser());

        public IClientPresenter GetClientPresenter() =>
            new ClientPresenter();
    }
}
