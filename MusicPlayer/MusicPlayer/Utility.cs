using System.Text;

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
