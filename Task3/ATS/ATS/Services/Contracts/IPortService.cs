using ATS.Models;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Services.Contracts
{
    public interface IPortService
    {
        void AddPort(IPort port);
        void CreatePort();
        IPort GetFreePort();
        IPort GetPortPhone(PhoneNumber phoneNumber);
    }
}
