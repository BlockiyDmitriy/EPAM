using System.Collections.Generic;

using Medialibrary.Interfaces.File;
using Medialibrary.Interfaces.Playlist;

namespace Medialibrary.Interfaces.Player
{
    public interface IPlayerFunctionality
    {
        void Play(ICollection<IFile> files);
        void PlayFile(IFile file);
        void PlayPlaylist(IPlaylist<IFile> playlists);
    }
}
