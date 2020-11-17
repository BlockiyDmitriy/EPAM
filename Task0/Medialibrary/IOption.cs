using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialibrary
{
    internal interface IOption
    {
        void Add();
        void Delete();
        string Search();
    }
}
