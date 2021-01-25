using ATS.Models;
using ATS.Models.Controllers.Contracts;
using BillingSystem.Models.Contracts;

namespace BillingSystem.Service.Contracts
{
    public interface IUserService
    {
        void ConnectToPort(IUser user, IPort port);
        void Call(IUser user, PhoneNumber phoneNumber);
        void Answer(IUser user);
    }
}
