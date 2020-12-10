using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Enum;
using TaxiStation.Interfaces.FuelEngines;

namespace TaxiStation
{
    public class GasCar : Car, IFuelEngines
    {
        public int TankCapacity { set; get; }
        public float FuelConsuption { set; get; }
        public GasCar(Brand brand, TypeCar typeCar, Engine engine, int price, string number,string color, string model, int minSpeed, int maxSpeed, int weigtht,
            int tankCapacity, float fuelConsuption)
            : base(brand, typeCar, engine, price, number, color, model, minSpeed, maxSpeed, weigtht)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsuption = fuelConsuption;
        }
        public override double GetHoursePowerPerTon()
        {
            return base.GetHoursePowerPerTon();
        }
    }
}
