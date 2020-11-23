using Medialibrary.Interfaces.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    class Video : File, IVideo
    {
        public string Genre { get; set; }
        public int FrameWidth { get; set; }
        public int FrameHeight { get; set; }
        public double Duration { get; set; }
        public Video(string type, string name, string author,
            string quality, int size, string location,
            string genre, int frameWidth, int frameHeight, double duration)
            : base(type, name, author, quality, size, location)
        {
            this.Genre = genre;
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.Duration = duration;
        }
    }
}
