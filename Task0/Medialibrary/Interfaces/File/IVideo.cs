using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary.Interfaces.File
{
    public interface IVideo : IAudioParam
    {
        int FrameWidth { get; set; }
        int FrameHeight { get; set; }
    }
}
