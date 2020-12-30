using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers
{
    internal class Port : IPort
    {
        private int CountPort { get; set; }
        public Port(int countPort)
        {
            this.CountPort = countPort;
        }
        public int GetCountPort() => CountPort;
    }
}
