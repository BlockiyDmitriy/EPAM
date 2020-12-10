using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStation.Interfaces
{
    public interface IAutopark
    {
        int CalculateCarsCost(ICollection<Car> cars);
        ICollection<Car> SearchBySpeed(ICollection<Car> cars, int minSpeed, int maxSpeed);
        ICollection<Car> SortByFuelConsumption(ICollection<Car> cars);
    }
}
