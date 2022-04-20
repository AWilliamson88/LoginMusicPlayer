using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMC_Music_Player.GUI
{
    internal interface ISendsMessages
    {
        event EventHandler<string> SendMessage;
        void SendToUserView(string message);
    }
}
