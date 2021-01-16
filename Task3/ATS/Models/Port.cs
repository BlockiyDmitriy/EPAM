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
        private ITerminal Terminal { get; set; } 
        public Port()
        {
            PortState = PortState.Free;
        }
        public ITerminal GetTerminal() => Terminal;
        public PortState GetPortState() => PortState;
        public void ChangePortState(PortState portState)
        {
            this.PortState = portState;
        }

        public event EventHandler<PhoneNumber> OutGoingCall;
        public event EventHandler<PhoneNumber> InComingCall;
        public event EventHandler Answer;
        public event EventHandler Drop;
        
        public void BindEventHundlerForTerminal(ITerminal terminal)
        {
            terminal.OutGoingCall += OnOutGoingCall;
            terminal.InComingCall += OnInComingCall;
            terminal.Answer += OnAnswer;
            terminal.Drop += OnDrop;
        }
        private void OnOutGoingCall(object sender, PhoneNumber phoneNumber)
        {
            OutGoingCall?.Invoke(this, phoneNumber);
        }
        private void OnInComingCall(object sender, PhoneNumber phoneNumber)
        {
            InComingCall?.Invoke(this, phoneNumber);
        }
        private void OnAnswer(object sender, EventArgs args)
        {
            Answer?.Invoke(this, args);
        }
        private void OnDrop(object sender, EventArgs args)
        {
            Drop?.Invoke(this, args);
        }
    }
}
