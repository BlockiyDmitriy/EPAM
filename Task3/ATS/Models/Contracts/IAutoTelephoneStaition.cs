using ATS.Services;
using ATS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers.Contracts
{
    internal interface IAutoTelephoneStaition: ICallService, IPortService
    {
        IPortService GetPorts();
        ICallService GetCall();
    }
}
