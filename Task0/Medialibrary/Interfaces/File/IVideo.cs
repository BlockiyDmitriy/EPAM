namespace Medialibrary.Interfaces.File
{
    public interface IVideo : IAudioParam
    {
        int FrameWidth { get; set; }
        int FrameHeight { get; set; }
    }
}
