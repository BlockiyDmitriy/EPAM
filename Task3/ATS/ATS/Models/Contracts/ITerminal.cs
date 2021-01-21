using ATS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers.Contracts
{
    public interface ITerminal
    {
        PhoneNumber GetNumber();
        IPort GetPort();
        Connection GetConnection();
        void RememberConnection(PhoneNumber from, PhoneNumber to);

        event EventHandler<PhoneNumber> OutGoingCall;
        event EventHandler<PhoneNumber> InComingCall;
        event EventHandler Answer;
        event EventHandler Drop;
        void Call(PhoneNumber phoneNumber);
        void GetCall(PhoneNumber phoneNumber);
        void AnswerCall();
        void DropCall();
        void ConnectToPort(IPort port);
    }
}
