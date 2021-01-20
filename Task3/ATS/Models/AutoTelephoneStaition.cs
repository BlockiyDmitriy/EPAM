using ATS.Services;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATS.Services.Contracts;
using ATS.Models.Contracts;

namespace ATS.Models
{
    public class AutoTelephoneStaition : IAutoTelephoneStaition
    {
        private IPortService Port { get; set; }
        private ICallService Call { get; set; }
        private ITerminalService TerminalService { get; set; }
        public AutoTelephoneStaition()
        {
            TerminalService = new TeriminalService();
            this.Port = new PortService();
            this.Call = new CallService();
        }
        public AutoTelephoneStaition(ICollection<IPort> ports) : this()
        {
            foreach (var item in ports)
            {
                AddPort(item);
            }
        }

        public IPortService GetPorts() => Port;
        public ICallService GetCall() => Call;
        public ITerminalService GetTerminal() => TerminalService;

        public void AddCallInfo(ICallInfo callInfo)
        {
            Call.AddCallInfo(callInfo);
        }

        public void CreateCallInfo()
        {
            Call.CreateCallInfo();
        }

        public void RemoveCallInfo(ICallInfo callInfo)
        {
            Call.RemoveCallInfo(callInfo);
        }

        public ICallInfo GetCallInfo(Connection connection)
        {
            return Call.GetCallInfo(connection);
        }

        public void AddPort(IPort port)
        {
            BindPortEvent(port);
            Port.AddPort(port);
        }

        public void CreatePort()
        {
            Port.CreatePort();
        }

        public IPort GetFreePort()
        {
            return Port.GetFreePort();
        }

        public IPort GetPortPhone(PhoneNumber phoneNumber)
        {
            return Port.GetPortPhone(phoneNumber);
        }
        protected virtual void BindPortEvent(IPort port)
        {
            port.OutGoingCall += OnOutGoingCall;
            port.InComingCall += OnInCommingCall;
            port.Answer += OnAnswer;
            port.Drop += OnDrop;
        }
        protected virtual void OnOutGoingCall(object sender, PhoneNumber phoneNumber)
        {
            var caller = sender as Port;
            var callInfo = new CallInfo(caller.GetTerminal().GetNumber(), phoneNumber, DateTime.Now, TimeSpan.Zero);

            caller.GetTerminal().RememberConnection(caller.GetTerminal().GetNumber(), phoneNumber);

            AddCallInfo(callInfo);

            var answerer = GetPortPhone(phoneNumber).GetTerminal();
            if (answerer.GetPort().GetPortState() == Enums.PortState.Free)
            {
                answerer.GetCall(caller.GetTerminal().GetNumber());
            }
            else
            {
                // reject
            }
        }
        protected virtual void OnInCommingCall(object sender, PhoneNumber phoneNumber)
        {
            if (sender is Port)
            {
                var inCommintTerminalCall = sender as Port;
                inCommintTerminalCall.ChangePortState(Enums.PortState.Busy);
                inCommintTerminalCall.GetTerminal().RememberConnection(inCommintTerminalCall.GetTerminal().GetNumber(), phoneNumber);
            }
        }
        protected virtual void OnAnswer(object sender, EventArgs args)
        {            
            var caller = GetPortPhone((sender as Port).GetTerminal().GetConnection().GetNumberFrom()).GetTerminal();
            var info = GetCallInfo(caller.GetConnection());
            var started = info.GetStarted();
            new CallInfo(caller.GetNumber(), info.GetTarget(), started, TimeSpan.Zero);
        }
        protected virtual void OnDrop(object sender, EventArgs args)
        {
            if (sender is Port)
            {
                if ((sender as Port).GetTerminal().GetConnection() != null) 
                {
                    var caller = GetPortPhone((sender as Port).GetTerminal().GetConnection().GetNumberFrom()).GetTerminal();
                    var info = Call.GetCallInfo(caller.GetConnection());
                    var answerer = GetPortPhone(caller.GetConnection().GetNumberTo()).GetTerminal();

                    if (caller.GetPort().GetPortState() == Enums.PortState.Busy)
                    {
                        var state = Enums.PortState.Free;
                    }
                    if (answerer.GetPort().GetPortState() == Enums.PortState.Busy)
                    {
                        var state = Enums.PortState.Free;
                    }
                    Call.AddCallInfo(info);
                }
            }
        }

    }
}
