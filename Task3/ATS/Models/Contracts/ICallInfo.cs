using ATS.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Contracts
{
    internal interface ICallInfo
    {
        PhoneNumber GetPhoneNumber();
        PhoneNumber GetTarget();
        DateTime GetStarted();
        TimeSpan GetDuration();
        CallState GetCallState();
    }
}
