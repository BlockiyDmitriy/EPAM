using ATS.Enums;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers
{
    internal class Port : IPort
    {
        private int NumberPort { get; set; }
        private PortState PortState { get; set; }

        public Port(int numberPort, PortState portState)
        {
            this.NumberPort = numberPort;
            this.PortState = PortState;
        }
        public int GetCountPort() => NumberPort;
        public PortState GetPortState() => PortState;
    }
}
