using ATS.Models.Controllers.Contracts;
using BillingSystem.Service.Contracts;
using System.Collections.Generic;

namespace BillingSystem.Models.Contracts
{
    public interface IBilling
    {
        ICallService GetCallService();
        IList<IUser> GetUsers();
        IUser GetUser(IUser user);
        void RegisterUser(IUser user);
        IPort GetFreePort();
    }
}
