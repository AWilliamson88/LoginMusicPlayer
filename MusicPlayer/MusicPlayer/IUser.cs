namespace MusicPlayer
{
    public interface IUser
    {
        string UserName { get; set; }

        User.State CurrentState { get; set; }
        User.Error LastError { get; set; }
    }
}