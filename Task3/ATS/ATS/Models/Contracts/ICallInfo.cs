using ATS.Enums;
using BillingSystem.Models;
using BillingSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Models.Contracts
{
    public interface ICallInfo
    {
        PhoneNumber GetPhoneNumber();
        PhoneNumber GetTarget();
        DateTime GetStarted();
        TimeSpan GetDuration();
        CallState GetCallState();
        IUser GetUser();
        double GetCost();
        string ToString();
    }
}
