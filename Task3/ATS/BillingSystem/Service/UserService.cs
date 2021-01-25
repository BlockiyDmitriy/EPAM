using ATS.Models;
using ATS.Models.Controllers.Contracts;
using BillingSystem.Models.Contracts;
using BillingSystem.Service.Contracts;

namespace BillingSystem.Service
{
    public class UserService : IUserService
    {
        public void ConnectToPort(IUser user, IPort port)
        {
            user.GetTerminal().ConnectToPort(port);
        }

        public void Call(IUser user, PhoneNumber phoneNumber)
        {
            user.GetTerminal().Call(phoneNumber);
        }
        public void Answer(IUser user)
        {
            user.GetTerminal().AnswerCall();
        }
        public void Drop(IUser user)
        {
            user.GetTerminal().DropCall();
        }
    }
}
