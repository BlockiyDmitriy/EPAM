using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary.Interfaces.File
{
    public interface IFile
    {
        string Type { get; set; }
        string Name { get; set; }
        string Author { get; set; }
        string Quality { get; set; }
        int Size { get; set; }
        string Location { get; set; }
    }
}
