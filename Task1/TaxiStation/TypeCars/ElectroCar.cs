using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Enum;

namespace TaxiStation
{
    public class ElectroCar : Car
    {
        public int ChargingTime { get; set; }
        public int LifeTime { get; set; }
            
        public ElectroCar(Brand brand, BodyCar typeCar, Engine engine, int price, string number,string color, string model, int minSpeed, int maxSpeed, int weigtht, //base
            int chargingTime, int lifeTime) 
            : base(brand, typeCar, engine, price, number,color, model, minSpeed, maxSpeed, weigtht)
        {
            this.ChargingTime = chargingTime;
            this.LifeTime = lifeTime;
        }
        public override double GetHoursePowerPerTon()
        {
            return base.GetHoursePowerPerTon();
        }
    }
}
