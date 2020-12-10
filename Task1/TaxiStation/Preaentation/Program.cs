using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Enum;

namespace TaxiStation
{
    class Program
    {
        static void Main(string[] args)
        {
            Autopark autopark = new Autopark();
            ICollection<Car> taxiCarsPoll = new List<Car>
            {
                new ElectroCar(Brand.Audi, BodyCar.Sedan, new Engine(244), 21000, "Red",
                "1111AB","A8", 0, 320, 2000, 60, 600),
                new GasCar(Brand.Audi, BodyCar.Sedan, new Engine(244), 21000, "Black",
                "1001AB","A8", 0, 320, 2000, 100, 7.7f),
                new PetrolCar(Brand.Audi, BodyCar.Sedan, new Engine(244), 21000, "White",
                "2001AB","A8", 0, 320, 2000, 100, 8.7f)
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
            ICollection<Car> carsSortedByFuelEconomy = autopark.SortByFuelConsumption(taxiCarsPoll);
            foreach (var item in carsSortedByFuelEconomy)
            {
                Console.WriteLine(item);
            }
        }
    }
}
