using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Services.Contracts
{
    public interface ITerminalService
    {
        ICollection<ITerminal> GetTerminal();
        ITerminal GetFreeTerminal();
        void AddTerminal(ITerminal terminal);
    }
}
