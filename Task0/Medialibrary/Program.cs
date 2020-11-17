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
            MedialibraryOfWork ofWork = new MedialibraryOfWork();

            Photo photo = new Photo("Photo", "author", "quality");
            Music music = new Music("Music", "author", "quality", "genre", 3.12);
            Video video = new Video("Video", "author", "quality");

            ofWork.Work(photo);
            ofWork.Work(music);
            ofWork.Work(video);
        }
    }
}
