namespace Medialibrary.Interfaces.File
{
    public interface IFile
    {
        string Type { get; set; }
        string Name { get; set; }
        string Author { get; set; }
        string Quality { get; set; }
        int Size { get; set; }
        string Location { get; set; }
    }
}
