using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    class Photo : AllMedia
    {
        IOption option;
        public Photo(string name, string author, string quality)
            : base(name, author, quality)
        {
            option = new Option();
        }
        public override void Playlist()
        {

        }
    }
}
