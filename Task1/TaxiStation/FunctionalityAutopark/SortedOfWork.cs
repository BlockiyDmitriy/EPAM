using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStation.FunctionalityAutopark
{
    class SortedOfWork
    {
        public void ActionSorted(ICollection<Car> cars, Car car)
        {
            car.SortByFuelConsumption(cars);
        }
    }
}
