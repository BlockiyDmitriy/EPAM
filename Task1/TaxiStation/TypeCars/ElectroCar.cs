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
        public override void SortByFuelConsumption(ICollection<Car> cars)
        {
            ICollection<ElectroCar> gasCars = new List<ElectroCar>();

            if (cars.Count == 0)
            {                
                //Nothing to sort
            }

            foreach (Car car in cars)
            {
                if (car is GasCar)
                {
                    gasCars.Add(car as ElectroCar);
                }
            }
            var resultGasCars = from i in gasCars
                                orderby i.LifeTime
                                select i;
            List<Car> result = new List<Car>();
            result.AddRange(resultGasCars);
        }
    }
}
