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
            MediaFiles.Add(file);
        }

        public void AddFileToPlaylist(IPlaylist<IFile> playlist, IFile file)
        {
            playlist.AddFile(file);
        }

        public void CreatePlaylist(IPlaylist<IFile> playlist)
        {
            PlaylistsFiles.Add(playlist);
        }

        public void DeleteFileFromMedialibrary(IFile file)
        {
            MediaFiles.Remove(file);
        }

        public void RemoveFileFromPlaylist(IPlaylist<IFile> playlist, IFile file)
        {
            playlist.DeleteFile(file);
        }

        public void RemovePlaylist(IPlaylist<IFile> playlist)
        {
            PlaylistsFiles.Remove(playlist);
        }

        public List<IFile> Search(string name)
        {
            List<IFile> matchedFiles = new List<IFile>();

            foreach (var file in MediaFiles)
            {
                if (file.Name.Contains(name))
                {
                    matchedFiles.Add(file);
                }
            }
            return matchedFiles;
        }


        public void Play()
        {
            Player.Play(MediaFiles);
        }

        public void PlayFile(IFile file)
        {
            Player.PlayFile(file);
        }
        public void PlayPlaylist(IPlaylist<IFile> playlist)
        {
            Player.PlayPlaylist(playlist);
        }
    }
}
