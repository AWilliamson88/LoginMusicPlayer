using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public static class Utility
    {
        public static string[] ConvertToString(byte[] message)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            string[] str = encoder.GetString(message).Split(',');
            return str;
        }
    }
}
