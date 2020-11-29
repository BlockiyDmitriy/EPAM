using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary.Interfaces.Playlist
{
    public interface IPlaylistData<TFile>
    {
        string Name { get; set; }
    }
}
