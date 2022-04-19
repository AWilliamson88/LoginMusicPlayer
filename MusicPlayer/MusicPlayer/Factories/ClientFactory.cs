using MusicPlayer.Forms;
using MusicPlayer.Ipc;

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
