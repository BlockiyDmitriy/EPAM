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

            PhoneNumber number1 = new PhoneNumber("+111111111111");
            PhoneNumber number2 = new PhoneNumber("+222222222222");

            ITerminal terminal1 = new Terminal(number1);
            ITerminal terminal2 = new Terminal(number2);

            IPort port1 = new Port(terminal1);
            IPort port2 = new Port(terminal2);

            IAutoTelephoneStaition autoTelephoneStaition = new AutoTelephoneStaition(
                new List<IPort>() { port1, port2 });

            terminal1.Call(number2);
            terminal1.AnswerCall();
            terminal1.DropCall();

            Billing system = new Billing(autoTelephoneStaition, new List<PhoneNumber>()
            {
                number1, number2
            });

            IUser user1 = new User("qqqq", 111);
            IUser user2 = new User("wwww", 222);

            system.RegisterUser(user1);
            system.RegisterUser(user2);

            UserService userService = new UserService();

            userService.ConnectToPort(user1, system.GetFreePort());
            userService.ConnectToPort(user2, system.GetFreePort());

            userService.Call(user1, number2);
            userService.Answer(user2);
            Thread.Sleep(2000);
            Console.WriteLine();
        }
    }
}
