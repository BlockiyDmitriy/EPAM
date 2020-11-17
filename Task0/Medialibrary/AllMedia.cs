using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    abstract class AllMedia
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Quality { get; set; }

        public AllMedia(string name, string author, string quality)
        {
            this.Name = name;
            this.Author = author;
            this.Quality = quality;
        }

        public virtual void Playlist()
        {

        }
    }
}
