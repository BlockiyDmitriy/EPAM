
using ATS.Controllers;
using ATS.Controllers.Services;
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
            IAutoTelephoneStaition autoTelephoneStaition = new AutoTelephoneStaition();

            PhoneNumber number1 = new PhoneNumber("+375331234567");
            PhoneNumber number2 = new PhoneNumber("+375331234568");

            ITerminal terminal1 = new Terminal(number1);
            ITerminal terminal2 = new Terminal(number2);
        }
    }
}
