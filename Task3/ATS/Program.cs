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
            IPort port = new Port(2, Enums.PortState.Connect);
            IPort port2 = new Port(3, Enums.PortState.Connect);
            ITerminal terminal = new Terminal(447222786, port);
            ITerminal terminal2 = new Terminal(299652511, port2);
            IAutoTelephoneStaition autoTelephoneStaition = new AutoTelephoneStaition(100, null, null, null);

            TerminalServices terminalServices = new TerminalServices();
            PortService portService = new PortService();
            ATSService aTS = new ATSService();

            // event binding
            terminalServices.Port += portService.OnPort;
            portService.ATS += aTS.OnATS;
            // generate event
            terminalServices.Connect(port);
            portService.Connect(autoTelephoneStaition);

            // event unbinding
            terminalServices.Port -= portService.OnPort;
            portService.ATS -= aTS.OnATS;
        }
    }
}
