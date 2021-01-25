using System;
using ATS.Enums;
using ATS.Models.Controllers.Contracts;

namespace ATS.Models
{
    public class Port : IPort
    {
        private PortState PortState { get; set; }
        private ITerminal Terminal { get; set; }
        public Port(ITerminal terminal)
        {
            BindTerminalToPort(terminal);
            PortState = PortState.Free;
            this.Terminal = terminal;
        }

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
        
        protected virtual void BindTerminalToPort(ITerminal terminal)
        {
            terminal.OutGoingCall += OnOutGoingCall;
            terminal.InComingCall += OnInComingCall;
            terminal.Answer += OnAnswer;
            terminal.Drop += OnDrop;
        }
        public virtual void UnBindTerminalToPort(ITerminal terminal)
        {
            terminal.OutGoingCall -= OnOutGoingCall;
            terminal.InComingCall -= OnInComingCall;
            terminal.Answer -= OnAnswer;
            terminal.Drop -= OnDrop;
        }
        protected void OnOutGoingCall(object sender, PhoneNumber phoneNumber)
        {
            OutGoingCall?.Invoke(this, phoneNumber);
        }
        protected void OnInComingCall(object sender, PhoneNumber phoneNumber)
        {
            InComingCall?.Invoke(this, phoneNumber);
        }
        protected void OnAnswer(object sender, EventArgs args)
        {
            Answer?.Invoke(this, args);
        }
        protected void OnDrop(object sender, EventArgs args)
        {
            Drop?.Invoke(this, args);
        }
    }
}
