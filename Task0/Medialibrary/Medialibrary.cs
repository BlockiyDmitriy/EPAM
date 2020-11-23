using Medialibrary.Interfaces.File;
using Medialibrary.Interfaces.Medialibrary;
using Medialibrary.Interfaces.Playlist;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    class Medialibrary : IMedialibrary
    {
        ICollection<IFile> MediaFiles { get; set; }
        ICollection<IPlaylist<IFile>> PlaylistsFiles { get; set; }
        public Medialibrary()
        {
            MediaFiles = new Collection<IFile>();
            PlaylistsFiles = new Collection<IPlaylist<IFile>>();
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

        public void PlayPlaylist(IPlaylist<IFile> playlist)
        {
            throw new NotImplementedException();
        }
    }
}
