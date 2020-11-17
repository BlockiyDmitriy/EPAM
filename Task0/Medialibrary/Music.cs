using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    class Music : AllMedia
    {
        IOption option;

        public string Genre { get; set; }
        public double Duration { get; set; }
        public Music(string name, string author, string quality, string genre, double duration)
            : base(name, author, quality)
        {
            option = new Option();
            this.Genre = genre;
            this.Duration = duration;
        }
        public override void Playlist()
        {

        }
    }
}
