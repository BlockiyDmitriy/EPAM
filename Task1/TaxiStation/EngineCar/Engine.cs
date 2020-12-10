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
        public int Power { get; private set; }
        public Engine(int power)
        {
            this.Power = power;
        }
    }
}
