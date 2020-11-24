namespace Medialibrary.Interfaces.File
{
    public interface IMusic : IAudioParam
    {
        string Artist { get; set; }
        string Album { get; set; }
        string Year { get; set; }
    }
}
