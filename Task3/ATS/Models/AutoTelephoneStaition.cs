using ATS.Services;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void BindPortEvent()
        {

        }
    }
}
