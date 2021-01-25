using System;
using ATS.Enums;
using BillingSystem.Models.Contracts;

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
