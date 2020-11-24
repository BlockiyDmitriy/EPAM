using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Medialibrary.Interfaces.File;

using Medialibrary.Interfaces.Medialibrary;
using Medialibrary.Interfaces.Player;
using Medialibrary.Interfaces.Playlist;

namespace Medialibrary
{
    public class Medialibrary : IMedialibrary
    {
        private ICollection<IFile> MediaFiles { get; set; }
        private ICollection<IPlaylist<IFile>> PlaylistsFiles { get; set; }
        private IPlayer Player { get; set; }
        public Medialibrary(IPlayer player)
        {
            MediaFiles = new Collection<IFile>();
            PlaylistsFiles = new Collection<IPlaylist<IFile>>();
            Player = player;
        }
        public void AddFileToMedialibrary(IFile file)
        {
            throw new NotImplementedException();
        }

        public void AddFileToPlaylist(IPlaylist<IFile> playlist, IFile file)
        {
            throw new NotImplementedException();
        }

        public void CreatePlaylist(IPlaylist<IFile> playlist)
        {
            throw new NotImplementedException();
        }

        public void DeleteFileFromMedialibrary(IFile file)
        {
            throw new NotImplementedException();
        }

        public void RemoveFileFromPlaylist(IPlaylist<IFile> playlist, IFile file)
        {
            throw new NotImplementedException();
        }

        public void RemovePlaylist(IPlaylist<IFile> playlist)
        {
            throw new NotImplementedException();
        }

        public List<IFile> Search(string name)
        {
            throw new NotImplementedException();
        }


        public void Play()
        {
            throw new NotImplementedException();
        }

        public void PlayFile(IFile file)
        {
            throw new NotImplementedException();
        }
        public void PlayPlaylist(IPlaylist<IFile> playlist)
        {
            throw new NotImplementedException();
        }
    }
}
