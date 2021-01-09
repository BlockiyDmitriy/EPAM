using ATS.Enums;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    internal class Port : IPort
    {
        private PortState PortState { get; set; }


        public PortState GetPortState() => PortState;

        public event EventHandler<ITerminal> OutGoingCall;
        public event EventHandler InComingCall;
        public event EventHandler Answer;
        public event EventHandler Drop;
        
        public void BindEvent(ITerminal terminal)
        {
            terminal.OutGoingCall += OnOutGoingCall;
            terminal.InComingCall += OnInComingCall;
            terminal.Answer += OnAnswer;
            terminal.Drop += OnDrop;
        }
        private void OnOutGoingCall(object sender, ITerminal terminal)
        {
            PortState = PortState.Busy;
            OutGoingCall?.Invoke(this, terminal);
        }
        private void OnInComingCall(object sender, EventArgs args)
        {
            PortState = PortState.Busy;
            InComingCall?.Invoke(this, args);
        }
        private void OnAnswer(object sender, EventArgs args)
        {
            PortState = PortState.InCall;
            Answer?.Invoke(this, args);
        }
        private void OnDrop(object sender, EventArgs args)
        {
            PortState = PortState.Free;
            Drop?.Invoke(this, args);
        }
    }
}
