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
        private PortController Ports { get; set; }
        public AutoTelephoneStaition()
        {
            this.Ports = new PortController();
        }
        public PortController GetPorts() => Ports;

        public void BindPortEvent()
        {

        }
    }
}
