using Medialibrary.Interfaces.File;

namespace Medialibrary
{
    public abstract class File : IFile
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Quality { get; set; }
        public int Size { get; set; }
        public string Location { get; set; }

        public File(string type, string name, string author,
            string quality, int size, string location)
        {
            this.Name = name;
            this.Type = type;
            this.Author = author;
            this.Quality = quality;
            this.Size = size;
            this.Location = location;

        }
    }
}
