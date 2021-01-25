using System;
using ATS.Models.Controllers.Contracts;

namespace ATS.Models
{
    public class Terminal : ITerminal
    {
        private PhoneNumber PhoneNumber { get; set; }
        private IPort Port { get; set; }
        private Connection Connection { get; set; }

        public Terminal(PhoneNumber number)
        {
            this.Port = new Port(this);
            this.PhoneNumber = number;
            BindToTerminal();
        }
        public PhoneNumber GetNumber() => PhoneNumber;
        public IPort GetPort() => Port;
        public Connection GetConnection() => Connection;

        public event EventHandler<PhoneNumber> OutGoingCall;
        public event EventHandler<PhoneNumber> InComingCall;
        public event EventHandler Answer;
        public event EventHandler Drop;
        public event EventHandler<IPort> ConnectingToPort;
        public void RememberConnection(PhoneNumber from, PhoneNumber to)
        {
            Connection = new Connection(from, to);
        }

        public void ConnectToPort(IPort port)
        {
            if (port.GetPortState() == Enums.PortState.Free && Port != null)
            {
                Port = port;
                Port.ChangePortState(Enums.PortState.ConnectedTerminal);
                OnConnect(port);
            }
            else
            {
                Console.WriteLine($"Port is busy");
            }
        }
        protected virtual void BindToTerminal()
        {
            OutGoingCall += (sender, phone) =>
            {
                var caller = sender as Terminal;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{caller.GetNumber().GetNumber()} calls to {phone.GetNumber()}");
                Console.ForegroundColor = ConsoleColor.White;
            };
            InComingCall += (sender, phone) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                var answerer = sender as Terminal;
                Console.WriteLine($"{answerer.GetNumber().GetNumber()} is calling {phone.GetNumber()}");
                Console.ForegroundColor = ConsoleColor.White;
            };
            Answer += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Call is started by {(sender as Terminal).GetNumber().GetNumber()}");
                Console.ForegroundColor = ConsoleColor.White;
            };
            Drop += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Call is drop by {(sender as Terminal).GetNumber().GetNumber()}");
                Console.ForegroundColor = ConsoleColor.White;
            };
            ConnectingToPort += (sender, e) =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var terminal = sender as Terminal;
                Console.WriteLine($"Terminal {terminal.GetNumber().GetNumber()} connected to port");
                Console.ForegroundColor = ConsoleColor.White;
            };
        }
        public void UnBindToTerminal()
        {
            OutGoingCall -= OnOutGoingCall;
            InComingCall -= OnInComingCall;
            Answer -= OnAnswer;
            Drop -= OnDrop;
        }
        protected virtual void OnConnect(IPort port)
        {
            ConnectingToPort?.Invoke(this, port);
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