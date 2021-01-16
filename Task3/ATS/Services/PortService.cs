using ATS.Enums;
using ATS.Models;
using ATS.Models.Controllers.Contracts;
using ATS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Services
{
    public class PortService: IPortService
    {
        private ICollection<IPort> _Ports;

        public PortService()
        {
            _Ports = new List<IPort>();
        }
        public void AddPort(IPort port)
        {
            _Ports.Add(port);
        }
        public void CreatePort()
        {
            AddPort(new Port());
        }
        public IPort GetFreePort()
        {
            return _Ports.Where(x => x.GetPortState() == PortState.Free).FirstOrDefault();
        }
        public IPort GetPortPhone(PhoneNumber phoneNumber)
        {
            return _Ports.FirstOrDefault(x => x.GetTerminal().GetNumber().Equals(phoneNumber));
        }
    }
}

