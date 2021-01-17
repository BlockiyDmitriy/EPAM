using ATS.Models;
using ATS.Models.Controllers.Contracts;
using BillingSystem.Models;
using BillingSystem.Models.BillingSystem;
using BillingSystem.Models.Contracts;
using BillingSystem.Service;
using BillingSystem.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            IPort port = new Port();

            PhoneNumber number1 = new PhoneNumber("+111111111111");
            PhoneNumber number2 = new PhoneNumber("+222222222222");
            PhoneNumber number3 = new PhoneNumber("+333333333333");

            ITerminal terminal1 = new Terminal(number1);
            ITerminal terminal2 = new Terminal(number2);
            ITerminal terminal3 = new Terminal(number3);

            IAutoTelephoneStaition autoTelephoneStaition = new AutoTelephoneStaition(new List<IPort>() { new Port(), new Port() }, new List<ITerminal>() { terminal1, terminal2, terminal3 });

            autoTelephoneStaition.AddPort(port);

            Billing system = new Billing(autoTelephoneStaition, new List<PhoneNumber>() { number1, number2, number3 });

            IUser user1 = new User("qqqq", 111);
            IUser user2 = new User("wwww", 222);
            IUser user3 = new User("eeee", 333);

            system.RegisterUser(user1);
            system.RegisterUser(user2);
            system.RegisterUser(user3);

            UserService userService = new UserService();

            userService.ConnectToPort(user1, system.GetFreePort());
            userService.ConnectToPort(user2, system.GetFreePort());
            userService.ConnectToPort(user3, system.GetFreePort());

            userService.Call(user1, number2);
            userService.Answer(user2);
            Thread.Sleep(2000);
            Console.WriteLine();
        }
    }
}
