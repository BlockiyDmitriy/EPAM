﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary.Interfaces.File
{
    public interface IAudioParam : IFile
    {
        string Genre { get; set; }
        double Duration { get; set; }
    }
}
