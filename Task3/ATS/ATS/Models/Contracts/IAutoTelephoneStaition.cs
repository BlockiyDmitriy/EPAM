using ATS.Models.Contracts;
using ATS.Services;
using ATS.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers.Contracts
{
    public interface IAutoTelephoneStaition //: ICallService, IPortService
    {
        IPortService GetPorts();
        ICallService GetCall();
        ITerminalService GetTerminal();

        void AddCallInfo(ICallInfo callInfo);
        void CreateCallInfo();
        void RemoveCallInfo(ICallInfo callInfo);
        ICallInfo GetCallInfo(Connection connection);

        void AddPort(IPort port);
        void CreatePort();
        IPort GetFreePort();
        IPort GetPortPhone(PhoneNumber phoneNumber);
    }
}
