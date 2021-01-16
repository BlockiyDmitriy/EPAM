using ATS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Controllers.Contracts
{
    internal interface ITerminal
    {
        PhoneNumber GetNumberFrom();
        PhoneNumber GetNumberTo();
        PhoneNumber GetNumber();
        IPort GetPort();


        event EventHandler<PhoneNumber> OutGoingCall;
        event EventHandler<PhoneNumber> InComingCall;
        event EventHandler Answer;
        event EventHandler Drop;
        void Call(PhoneNumber phoneNumber);
        void GetCall(PhoneNumber phoneNumber);
        void AnswerCall();
        void DropCall();
    }
}
