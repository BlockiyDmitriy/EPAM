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
        private PhoneNumber From { get; set; }
        private PhoneNumber To { get; set; }
        private PhoneNumber PhoneNumber { get; set; }
        private IPort Port { get; set; }
        public Terminal(PhoneNumber number)
        {
            Port = new Port();
            this.PhoneNumber = number;
            RegisterEventHandlerForTerminal();
        }
        public PhoneNumber GetNumberFrom() => From;
        public PhoneNumber GetNumberTo() => To;
        public PhoneNumber GetNumber() => PhoneNumber;
        public IPort GetPort() => Port;

        public event EventHandler<PhoneNumber> OutGoingCall;
        public event EventHandler<PhoneNumber> InComingCall;
        public event EventHandler Answer;
        public event EventHandler Drop;

        protected virtual void RegisterEventHandlerForTerminal()
        {
            OutGoingCall += (sender, phone) =>
            {
                var caller = sender as Terminal;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{caller.GetNumber()} calls to {phone.GetNumber()}");
                Console.ForegroundColor = ConsoleColor.White;
            };
            InComingCall += (sender, phone) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                var answerer = sender as Terminal;
                Console.WriteLine($"{answerer.GetNumber()} is calling {phone.GetNumber()}");
                Console.ForegroundColor = ConsoleColor.White;
            };
            Answer += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Call is started by {(sender as Terminal).GetNumber()}");
                Console.ForegroundColor = ConsoleColor.White;
            };
            Drop += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Call is rejected by {(sender as Terminal).GetNumber()}");
                Console.ForegroundColor = ConsoleColor.White;
            };
        }
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
