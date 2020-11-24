using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary.Interfaces.File
{
    public interface IMusic : IAudioParam
    {
        string Artist { get; set; }
        string Album { get; set; }
        string Year { get; set; }
    }
}
