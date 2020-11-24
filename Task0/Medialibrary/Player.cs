using System;
using System.Collections.Generic;

using Medialibrary.Interfaces.File;
using Medialibrary.Interfaces.Player;
using Medialibrary.Interfaces.Playlist;

namespace Medialibrary
{
    public class Player : IPlayer
    {
        public Player()
        {

        }

        public void Play(ICollection<IFile> files)
        {
            throw new NotImplementedException();
        }

        public void PlayFile(IFile file)
        {
            throw new NotImplementedException();
        }

        public void PlayPlaylist(IPlaylist<IFile> playlists)
        {
            throw new NotImplementedException();
        }
    }
}
