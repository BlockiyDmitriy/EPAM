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
            PhoneNumber number = new PhoneNumber("+375331234567");

            ITerminal terminal = new Terminal(number);
            IPort port = new Port();
            IAutoTelephoneStaition autoTelephoneStaition = new AutoTelephoneStaition();

            autoTelephoneStaition.AddPort(port);
            terminal.Call(number);
        }
    }
}
