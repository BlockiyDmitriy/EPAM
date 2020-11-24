using System.Collections.Generic;

using Medialibrary.Interfaces.File;
using Medialibrary.Interfaces.Playlist;

namespace Medialibrary.Interfaces.Medialibrary
{
    public interface IMedialibraryFunctionality
    {
        void AddFileToMedialibrary(IFile file);
        void DeleteFileFromMedialibrary(IFile file);
        void AddFileToPlaylist(IPlaylist<IFile> playlist, IFile file);
        void RemoveFileFromPlaylist(IPlaylist<IFile> playlist, IFile file);
        void CreatePlaylist(IPlaylist<IFile> playlist);
        void RemovePlaylist(IPlaylist<IFile> playlist);
        List<IFile> Search(string name);
        void Play();
        void PlayFile(IFile file);
        void PlayPlaylist(IPlaylist<IFile> playlist);
    }
}
