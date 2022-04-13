using static Music_Player.GUI.PasswordProcessor;

namespace Music_Player.GUI
{
    static class UserDetailsProcessor
    {
        public static string ProcessUserDetails(string username, string password)
        {
            string passwordHash = GeneratePasswordHash(password + username);
            return $"{username},{passwordHash}";
        }

    }
}
