using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Forms
{
    public interface IUserView
    {
        event EventHandler<string> MessageToServer;

        void UpdateTheForm(User.State state);
    }
}
