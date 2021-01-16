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
        public AutoTelephoneStaition()
        {
            this.Port = new PortService();
            this.Call = new CallService();
        }

        public IPortService GetPorts() => Port;
        public ICallService GetCall() => Call;

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

        public ICallInfo GetCallInfo(string from, string to)
        {
            return Call.GetCallInfo(from, to);
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

        private void BindPortEvent(IPort port)
        {
            port.OutGoingCall += OnOutGoingCall;
            port.InComingCall += OnInCommingCall;
            port.Answer += OnAnswer;
            port.Drop += OnDrop;
        }
        private void OnOutGoingCall(object sender, PhoneNumber phoneNumber)
        {
            var caller = sender is Terminal ? sender as Terminal : throw new Exception();
            ICallInfo callInfo = new CallInfo(caller.GetNumber(), phoneNumber, DateTime.Now, TimeSpan.Zero);
            Call.AddCallInfo(callInfo);

            var answerer = GetPortPhone(phoneNumber).GetTerminal();
            if (answerer.GetPort().GetPortState() == Enums.PortState.Free)
            {
                answerer.GetCall(caller.GetNumber());
            }
        }
        private void OnInCommingCall(object sender, PhoneNumber phoneNumber)
        {
            if (sender is Terminal)
            {
                var inCommintTerminalCall = sender as Terminal;
                inCommintTerminalCall.GetPort().ChangePortState(Enums.PortState.Busy);
            }
        }
        private void OnAnswer(object sender, EventArgs args)
        {
            var caller = GetPortPhone((sender as Terminal).GetNumberFrom()).GetTerminal();
            var info = Call.GetCallInfo(caller.GetNumberFrom().GetNumber(), caller.GetNumberTo().GetNumber());
            var started = info.GetStarted();
            ICallInfo callInfo = new CallInfo(started);
        }
        private void OnDrop(object sender, EventArgs args)
        {
            if (sender is Terminal)
            {
                if (((sender as Terminal).GetNumberFrom() != null) &&
                    ((sender as Terminal).GetNumberTo() != null))
                {
                    var caller = GetPortPhone((sender as Terminal).GetNumberFrom()).GetTerminal();
                    var info = Call.GetCallInfo(caller.GetNumberFrom().GetNumber(), caller.GetNumberTo().GetNumber());
                    var answerer = GetPortPhone(caller.GetNumberTo()).GetTerminal();

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
