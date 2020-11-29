using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStation.Interfaces
{
    public interface IAutoparkFuntionality
    {
        int CalculateCarsCost(List<Car> cars);
        List<Car> SortByFuelConsumption(List<Car> cars, int minSpeed, int maxSpeed);
        List<Car> SearchBySpeed(List<Car> cars);
    }
}
