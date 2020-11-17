using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    class Video : AllMedia
    {
        IOption option;
        public Video(string name, string author, string quality)
            : base(name, author, quality)
        {
            option = new Option();
        }
        public override void Playlist()
        {

        }
    }
}
