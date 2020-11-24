using Medialibrary.Interfaces.File;
using Medialibrary.Interfaces.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary.Interfaces.Player
{
    public interface IPlayerFunctionality
    {
        void Play(ICollection<IFile> files);
        void PlayFile(IFile file);
        void PlayPlaylist(IPlaylist<IFile> playlists);
    }
}
