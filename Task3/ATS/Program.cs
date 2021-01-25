using ATS.Models;
using ATS.Models.Controllers.Contracts;
using BillingSystem.Models;
using BillingSystem.Models.BillingSystem;
using BillingSystem.Models.Contracts;
using BillingSystem.Service;
using BillingSystem.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ATS
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneNumber number1 = new PhoneNumber("+111111111111");
            PhoneNumber number2 = new PhoneNumber("+222222222222");

            ITerminal terminal1 = new Terminal(number1);
            ITerminal terminal2 = new Terminal(number2);

            IPort port1 = new Port(terminal1);
            IPort port2 = new Port(terminal2);

            IAutoTelephoneStaition autoTelephoneStaition = new AutoTelephoneStaition(
                new List<IPort>() { port1, port2 });

            IBilling system = new Billing(autoTelephoneStaition, new List<PhoneNumber>()
            {
                number1, number2
            });

            IUser user1 = new User(Guid.NewGuid(), "qqqq", 111);
            IUser user2 = new User(Guid.NewGuid(), "wwww", 222);

            system.RegisterUser(user1);
            system.RegisterUser(user2);

            IUserService userService = new UserService();

            userService.ConnectToPort(system.GetUser(user1), system.GetFreePort());
            userService.ConnectToPort(system.GetUser(user2), system.GetFreePort());

            userService.Call(system.GetUser(user1), number2);
            userService.Answer(system.GetUser(user2));
            Thread.Sleep(2000);
            Console.WriteLine();

        }
    }
}
