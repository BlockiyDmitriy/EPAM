using ATS.Models;
using ATS.Models.Controllers;
using ATS.Models.Controllers.Contracts;
using ATS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
{
    class Program
    {
        static void Main(string[] args)
        {

            // create objects
            IPort port = new Port(2, Enums.PortState.Free);
            IPort port2 = new Port(3, Enums.PortState.Free);
            ITerminal terminal = new Terminal("+375447222786", port);
            ITerminal terminal2 = new Terminal("+375299652511", port2);

            IEnumerable<IPort> ports = new List<IPort> { port, port2 };
            IEnumerable<ITerminal> terminals = new List<ITerminal> { terminal, terminal2 };

            IAutoTelephoneStaition autoTelephoneStaition = new AutoTelephoneStaition(ports, terminals );

            TerminalServices terminalServices = new TerminalServices();
            PortService portService = new PortService();
            ATSService aTS = new ATSService();

            // event binding
            terminalServices.Port += portService.OnPort;
            portService.ATS += aTS.OnATS;

            // generate event
            terminalServices.GetNumber(port);
            portService.Connect(autoTelephoneStaition);

            // event unbinding
            terminalServices.Port -= portService.OnPort;
            portService.ATS -= aTS.OnATS;
        }
    }
}
