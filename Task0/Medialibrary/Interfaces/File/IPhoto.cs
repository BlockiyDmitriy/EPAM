﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary.Interfaces.File
{
    internal interface IPhoto : IFile
    {
        int Width { get; set; }
        int Height { get; set; }
    }
}
