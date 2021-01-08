using ATS.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers.Contracts
{
    internal interface IAutoTelephoneStaition
    {
        TerminalController GetTerminal();
        PortController GetPorts();
    }
}
