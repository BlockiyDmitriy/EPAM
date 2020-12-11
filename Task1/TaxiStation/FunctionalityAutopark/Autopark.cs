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
        public Autopark()
        {

        }
        public int CalculateCarsCost(ICollection<Car> cars)
        {
            int sum = 0;
            foreach (Car car in cars)
            {
                sum = sum + car.Price;
            }
            return sum;
        }

        public ICollection<Car> SearchBySpeed(ICollection<Car> cars, int min, int max)
        {
            ICollection<Car> carSelection = new List<Car>();

            foreach (Car car in cars)
            {
                if (car.MaxSpeed >= min && car.MaxSpeed <= max)
                {
                    carSelection.Add(car);
                }
            }

            return carSelection;
        }

    }
}
