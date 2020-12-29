using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models
{
    internal class AutoTelephoneStaition
    {
        public int AmountPorts { get; private set; }
        private IEnumerable<int> EmployedPorts { get; set; }
        private IEnumerable<int> FreePorts { get; set; }
        private IEnumerable<Dialog> AllCall { get; set; }
        public AutoTelephoneStaition(int amountPorts, IEnumerable<int> employedPorts, IEnumerable<int> freePorts, IEnumerable<Dialog> allCall)
        {
            this.AmountPorts = amountPorts;
            this.EmployedPorts = employedPorts;
            this.FreePorts = freePorts;
            this.AllCall = allCall;
        }
        public IEnumerator<int> GetEmployedPorts()
        {
            return EmployedPorts.GetEnumerator();
        }
        public IEnumerator<int> GetFreePorts()
        {
            return FreePorts.GetEnumerator();
        }
        public IEnumerator<Dialog> GetAllCall()
        {
            return AllCall.GetEnumerator();
        }

    }
}
