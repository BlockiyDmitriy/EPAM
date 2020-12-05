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

        public ICollection<Car> SortByFuelConsumption(ICollection<Car> cars)
        {
            ICollection<GasCar> gasCars = new List<GasCar>();
            ICollection<ElectroCar> electroCars = new List<ElectroCar>();
            ICollection<PetrolCar> petrolCars = new List<PetrolCar>();

            if (cars.Count == 0)
            {
                //Nothing to sort
            }

            foreach (Car car in cars)
            {
                if (car is ElectroCar)
                {
                    electroCars.Add(car as ElectroCar);
                }
                else if (car is GasCar)
                {
                    gasCars.Add(car as GasCar);
                }
                else if (car is PetrolCar)
                {
                    petrolCars.Add(car as PetrolCar);
                }
            }
            //попробовать реализовать сортировку с помощью Linq

            return null;
        }
    }
}
