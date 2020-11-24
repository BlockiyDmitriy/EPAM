using Medialibrary.Interfaces.File;
using Medialibrary.Interfaces.Player;
using Medialibrary.Interfaces.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    class Player : IPlayer
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
