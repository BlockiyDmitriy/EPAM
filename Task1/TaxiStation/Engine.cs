using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Enum;

namespace TaxiStation
{
    public class Engine
    {
        private TypeEngine TypeEngine { get; set; }
        private int Power { get; set; }
        public Engine(int power)
        {
            Power = power;
        }
    }
}
