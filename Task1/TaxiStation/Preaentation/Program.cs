using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Enum;
using TaxiStation.FunctionalityAutopark;
using TaxiStation.Interfaces;

namespace TaxiStation
{
    class Program
    {
        static void Main(string[] args)
        {
            IAutopark autopark = new Autopark();
            ElectroCar electroCar = new ElectroCar(Brand.Audi, BodyCar.Sedan, new Engine(244), 21000, "Red",
            "1111AB", "A8", 0, 320, 2000, 60, 600);
            GasCar gasCar = new GasCar(Brand.Audi, BodyCar.Sedan, new Engine(244), 21000, "Black",
            "1001AB", "A8", 0, 320, 2000, 100, 7.7f);
            PetrolCar petrolCar = new PetrolCar(Brand.Audi, BodyCar.Sedan, new Engine(244), 21000, "White",
            "2001AB", "A8", 0, 320, 2000, 100, 8.7f);
            ICollection<Car> taxiCarsPoll = new List<Car>
            {
                electroCar,
                gasCar,
                petrolCar
            };

            long carsCost = autopark.CalculateCarsCost(taxiCarsPoll);
            Console.WriteLine($"Autopark total cost is ${carsCost}");
            Console.WriteLine();

            ICollection<Car> carsBySpeed = autopark.SearchBySpeed(taxiCarsPoll, 0, 100);
            foreach (Car car in carsBySpeed)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine();

            //ICollection<Car> carsSortedByFuelEconomy = autopark.SortByFuelConsumption(taxiCarsPoll);
            //foreach (var item in carsSortedByFuelEconomy)
            //{
            //    Console.WriteLine(item);
            //}

            SortedOfWork sortedOfWork = new SortedOfWork();

            foreach (var item in taxiCarsPoll)
            {
                sortedOfWork.ActionSorted(taxiCarsPoll, item);
            }
        }
    }
}
