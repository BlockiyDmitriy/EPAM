namespace Medialibrary.Interfaces.File
{
    public interface IAudioParam : IFile
    {
        string Genre { get; set; }
        double Duration { get; set; }
    }
}
