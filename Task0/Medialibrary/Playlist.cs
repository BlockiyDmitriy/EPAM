using Medialibrary.Interfaces.File;
using Medialibrary.Interfaces.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    class Playlist<TFile> : IPlaylist<TFile> where TFile : IFile
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
