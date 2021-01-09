using ATS.Models;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Services
{
    internal class PortController
    {
        private IDictionary<PhoneNumber, IPort> Ports { get; set; }

        public PortController()
        {
            Ports = new Dictionary<PhoneNumber, IPort>();
        }

        public IPort GeneratePort()
        {
            return null;
        }
    }
}

