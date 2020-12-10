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

        public ICollection<Car> SortByFuelConsumption(ICollection<Car> cars)
        {
            //уменьшить кол-во повтор строк
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
            var resultGasCars = from i in gasCars
                         orderby i.FuelConsuption
                         select i;
            var resultElectroCars = from i in electroCars
                         orderby i.LifeTime
                         select i;
            var resultPetrolCars = from i in petrolCars
                         orderby i.FuelConsuption
                         select i;
            List<Car> result = new List<Car>();
            result.AddRange(resultGasCars);
            result.AddRange(resultElectroCars);
            result.AddRange(resultPetrolCars);
                
            return result;
        }
    }
}
