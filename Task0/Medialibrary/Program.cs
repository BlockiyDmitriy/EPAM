﻿using Medialibrary.Interfaces.File;
using Medialibrary.Interfaces.Medialibrary;
using Medialibrary.Interfaces.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            IMedialibrary ofWork = new Medialibrary(new Player());

            IPlaylist<IFile> playlist = new Playlist<IFile>();

            IPhoto photo = new Photo("jpg", "MyPhoto", "Sasha", "1920x1080", 200, @"E:\MyPhotos", 1920, 1080);
            IMusic music = new Music("mp3", "MyMusic", "Sergey", "320 кбит/с", 15, @"E:\MyMusic", "Rock", "Malcolm", "Blow Up Your Video", "1990", 3.12);
            IVideo video = new Video("mp4", "MyVido", "Dima", "FullHD", 10000, @"E:\MyVideo", "Fiction", 1920, 1080, 120.50);

            playlist.AddFile(photo);
            playlist.AddFile(music);
            playlist.AddFile(video);

            ofWork.CreatePlaylist(playlist);
        }
    }
}
