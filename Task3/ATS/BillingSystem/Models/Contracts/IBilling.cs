using ATS.Models.Controllers.Contracts;

namespace BillingSystem.Models.Contracts
{
    public interface IBilling
    {
        IUser GetUser(IUser user);
        void RegisterUser(IUser user);
        IPort GetFreePort();
    }
}
