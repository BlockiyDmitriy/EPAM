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
        public ICollection<Car>  SortByFuelConsumption(ICollection<Car> cars)
        {
            ICollection<ElectroCar> electroCar = new List<ElectroCar>();

            if (cars.Count == 0)
            {
                //Nothing to sort
            }

            foreach (Car car in cars)
            {
                if (car is ElectroCar)
                {
                    electroCar.Add(car as ElectroCar);
                }
            }
            var resultGasCars = from i in electroCar
                                orderby i.LifeTime
                                select i;
            List<Car> result = new List<Car>();
            result.AddRange(resultGasCars);
        }
    }
}
