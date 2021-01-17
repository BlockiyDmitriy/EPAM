using ATS.Models;
using ATS.Models.Controllers.Contracts;
using BillingSystem.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.Service
{
    public class UserService
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

    }
}
