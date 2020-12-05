using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Enum;

namespace TaxiStation
{
    public class GasCar : Car
    {
        public int TankCapacity { set; get; }
        public int FuelEconomy { set; get; }
        public GasCar(int tankCapacity, int fuelEconomy,
            Brand brand, TypeCar typeCar, Engine engine, int price, string number,string color, string model, int minSpeed, int maxSpeed, int weigtht)
            : base(brand, typeCar, engine, price, number, color, model, minSpeed, maxSpeed, weigtht)
        {
            this.TankCapacity = tankCapacity;
            this.FuelEconomy = fuelEconomy;
        }
        public override double GetHoursePowerPerTon()
        {
            return base.GetHoursePowerPerTon();
        }
    }
}
