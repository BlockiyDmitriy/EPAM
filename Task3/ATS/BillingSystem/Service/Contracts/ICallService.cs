using ATS.Enums;
using ATS.Models;
using ATS.Models.Contracts;
using BillingSystem.Models.Contracts;

namespace BillingSystem.Service.Contracts
{
    public interface ICallService
    {
        void AddCall(ICallInfo info);
        void SetAdditionalInfo(IUser user, ICallInfo callInfo);
        void GetUserCallsPerMonth(IUser user);
        void GetUserCallsByCallStatePerMonth(IUser user, CallState callState);
        void GetUserCallsByDate(IUser user, int days);
        void GetUserCallsByDuration(IUser user, int minutes, int seconds);
        void GetUserCallsByCost(IUser user, double cost);
        void GetUserCallsByUser(IUser user, PhoneNumber number);
    }
}
