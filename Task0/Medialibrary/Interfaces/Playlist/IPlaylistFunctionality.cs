using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary.Interfaces.Playlist
{
    public interface IPlaylistFunctionality<TFile>
    {
        void AddFile(TFile file);
        void DeleteFile(TFile file);

    }
}
