using ATS.Models;
using ATS.Models.Controllers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATS
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

            IAutoTelephoneStaition autoTelephoneStaition = new AutoTelephoneStaition();

            autoTelephoneStaition.AddPort(port);
            terminal1.Call(number1);
        }
    }
}
