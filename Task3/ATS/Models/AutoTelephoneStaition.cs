using ATS.Controllers;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    internal class AutoTelephoneStaition : IAutoTelephoneStaition
    {
        private TerminalController Terminals { get; set; }
        private PortController Ports { get; set; }
        public AutoTelephoneStaition()
        {
            this.Terminals = new TerminalController();
            this.Ports = new PortController();
        }
        public TerminalController GetTerminal() => Terminals;
        public PortController GetPorts() => Ports;

        public void StartWorkTerminal(ITerminal terminal)
        {
            BindingEventFromTerminal(terminal);
        }
        private void BindingEventFromTerminal(ITerminal terminal)
        {
            terminal.OutGoingCall += OnOutGoingCall;
            terminal.Answer += OnAnswer;
            terminal.Drop += OnDrop;
        }

        private void OnOutGoingCall(object sender, ITerminal terminal)
        {

        }
        private void OnAnswer(object sender, EventArgs args)
        {

        }
        private void OnDrop(object sender, EventArgs args)
        {

        }
    }
}
