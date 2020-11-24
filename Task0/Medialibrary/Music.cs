using Medialibrary.Interfaces.File;

namespace Medialibrary
{
    public class Music : File, IMusic
    {
        public string Genre { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public double Duration { get; set; }

        public Music(string type, string name, string author,
            string quality, int size, string location,
            string genre, string artist, string album, string year, double duration)
            : base(type, name, author, quality, size, location)
        {
            this.Genre = genre;
            this.Artist = artist;
            this.Album = album;
            this.Year = year;
            this.Duration = duration;
        }
    }
}
