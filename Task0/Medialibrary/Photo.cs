using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    class Photo : File
    {

        public int Width { get; set; }

        public int Height { get; set; }
        public Photo(string type, string name, string author,
            string quality, int size, string location,
            int width, int height)
            : base(type, name, author, quality, size, location)
        {
            this.Width = width;
            this.Height = height;
        }
        public override void Playlist()
        {

        }
    }
}
