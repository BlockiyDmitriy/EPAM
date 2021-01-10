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
            Port = new Port();
            this.PhoneNumber = number;
        }
        public PhoneNumber GetNumber() => PhoneNumber;
        public IPort GetPort() => Port;

        public event EventHandler<PhoneNumber> OutGoingCall;
        public event EventHandler<PhoneNumber> InComingCall;
        public event EventHandler Answer;
        public event EventHandler Drop;

        protected virtual void OnOutGoingCall(object sender, PhoneNumber phoneNumber)
        {            
            OutGoingCall?.Invoke(this, phoneNumber);
        }
        protected virtual void OnInComingCall(object sender, PhoneNumber phoneNumber)
        {
            InComingCall?.Invoke(this, phoneNumber);
        }
        protected virtual void OnAnswer(object sender, EventArgs args)
        {
            Answer?.Invoke(this, args);
        }
        protected virtual void OnDrop(object sender, EventArgs args)
        {
            Drop?.Invoke(this, args);
        }

        public void Call(PhoneNumber phoneNumber)
        {
            if ((Port.GetPortState() == Enums.PortState.Free) &&
                (phoneNumber != null))
            {
                OnOutGoingCall(this, phoneNumber);
            }            
        }
        public void GetCall(PhoneNumber phoneNumber)
        {
            
            OnInComingCall(this, phoneNumber);
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
