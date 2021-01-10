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
            PhoneNumber number1 = new PhoneNumber("+375331234567");

            ITerminal terminal1 = new Terminal(number1);


        }
    }
}
