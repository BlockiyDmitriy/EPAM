using System;

using Medialibrary.Interfaces.File;
using Medialibrary.Interfaces.Playlist;

namespace Medialibrary
{
    public class Playlist<TFile> : IPlaylist<TFile> where TFile : IFile
    {
        public Playlist()
        {
        }
        public void AddFile(TFile file)
        {
            throw new NotImplementedException();
        }

        public void DeleteFile(TFile file)
        {
            throw new NotImplementedException();
        }
    }
}
