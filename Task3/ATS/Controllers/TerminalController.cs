using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Controllers
{
    internal class TerminalController
    {
        private ICollection<ITerminal> Terminals { get; set; }
    }
}
