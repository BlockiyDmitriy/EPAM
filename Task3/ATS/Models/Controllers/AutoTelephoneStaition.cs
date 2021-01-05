using ATS.Models.BillingSystem;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers
{
    internal class AutoTelephoneStaition : IAutoTelephoneStaition
    {
        private IEnumerable<ITerminal> Terminals { get; set; }
        private IEnumerable<IPort> Ports { get; set; }
        public AutoTelephoneStaition(IEnumerable<IPort> ports, IEnumerable<ITerminal> terminals)
        {
            this.Terminals = terminals;
            this.Ports = ports;
        }
        public IEnumerator<ITerminal> GetTerminal() => Terminals.GetEnumerator();
        public IEnumerator<IPort> GetPorts() => Ports.GetEnumerator();
    }
}
