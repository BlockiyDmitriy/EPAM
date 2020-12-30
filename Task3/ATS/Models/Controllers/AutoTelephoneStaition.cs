using ATS.Models.BillingSystem;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers
{
    internal class AutoTelephoneStaition : IAutoTelephoneStaition
    {
        private int AmountPorts { get; set; }
        private IEnumerable<int> EmployedPorts { get; set; }
        private IEnumerable<int> FreePorts { get; set; }
        private IEnumerable<DialogInformation> AllCall { get; set; }
        public AutoTelephoneStaition(int amountPorts, IEnumerable<int> employedPorts, IEnumerable<int> freePorts, IEnumerable<DialogInformation> allCall)
        {
            this.AmountPorts = amountPorts;
            this.EmployedPorts = employedPorts;
            this.FreePorts = freePorts;
            this.AllCall = allCall;
        }
        public int GetAmountPorts() => AmountPorts;
        public IEnumerator<int> GetEmployedPorts() => EmployedPorts.GetEnumerator();
        public IEnumerator<int> GetFreePorts() => FreePorts.GetEnumerator();
        public IEnumerator<DialogInformation> GetAllPorts() => AllCall.GetEnumerator();
    }
}
