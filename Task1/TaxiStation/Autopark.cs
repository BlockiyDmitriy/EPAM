using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Interfaces;

namespace TaxiStation
{
    class Autopark : IAutopark
    {
        public int CalculateCarsCost(List<Car> cars)
        {
            throw new NotImplementedException();
        }

        public List<Car> SearchBySpeed(List<Car> cars)
        {
            throw new NotImplementedException();
        }

        public List<Car> SortByFuelConsumption(List<Car> cars, int minSpeed, int maxSpeed)
        {
            throw new NotImplementedException();
        }
    }
}
