using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.BLL.Abstraction;

namespace Task4.BLL.Managers
{
    public interface IFileManager : IControlProcess
    {
        string SourceFolder { get; }
        string DestFolder { get; }

        event EventHandler<string> New;
        void BackUp(string fileName);
    }
}
