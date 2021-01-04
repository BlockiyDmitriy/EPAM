using ATS.Models.BillingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers.Contracts
{
    internal interface IAutoTelephoneStaition
    {
        int GetNumber();
        int GetAmountPorts();
        IEnumerator<int> GetEmployedPorts();
        IEnumerator<int> GetFreePorts();
        IEnumerator<DialogInformation> GetAllPorts();
    }
}
