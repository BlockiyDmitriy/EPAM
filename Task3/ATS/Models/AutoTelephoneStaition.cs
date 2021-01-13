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
    internal class AutoTelephoneStaition : IAutoTelephoneStaition
    {
        private PortService Port { get; set; }
        private CallService Call { get; set; }
        public AutoTelephoneStaition()
        {
            this.Port = new PortService();
        }

        public PortService GetPorts() => Port;
        public CallService GetCall() => Call;

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

        }
        private void OnInCommingCall(object sender, PhoneNumber phoneNumber)
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
