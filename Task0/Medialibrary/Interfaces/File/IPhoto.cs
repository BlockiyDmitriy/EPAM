namespace Medialibrary.Interfaces.File
{
    public interface IPhoto : IFile
    {
        int Width { get; set; }
        int Height { get; set; }
    }
}
