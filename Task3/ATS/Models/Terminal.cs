using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    internal class Terminal : ITerminal
    {
        private PhoneNumber PhoneNumber { get; set; }
        private IPort Port { get; set; }
        public Terminal(PhoneNumber number)
        {
            this.PhoneNumber = number;
        }
        public PhoneNumber GetNumber() => PhoneNumber;
        public IPort GetPort() => Port;

        public event EventHandler<ITerminal> OutGoingCall;
        public event EventHandler InComingCall;
        public event EventHandler Answer;
        public event EventHandler Drop;
        protected virtual void OnOutGoingCall(object sender, ITerminal turget)
        {            
            OutGoingCall?.Invoke(this, turget);
        }
        protected virtual void OnInComingCall(object sender, EventArgs args)
        {
            InComingCall?.Invoke(this, args);
        }
        protected virtual void OnAnswer(object sender, EventArgs args)
        {
            Answer?.Invoke(this, args);
        }
        protected virtual void OnDrop(object sender, EventArgs args)
        {
            Drop?.Invoke(this, args);
        }

        public void Call(ITerminal phoneNumber)
        {
            if ((Port.GetPortState() == Enums.PortState.Free) &&
                (phoneNumber != null))
            {
                OnOutGoingCall(this, phoneNumber);
            }            
        }
        public void AnswerCall()
        {
            OnAnswer(this, null);
        }
        public void DropCall()
        {
            OnDrop(this, null);
        }
    }
}
