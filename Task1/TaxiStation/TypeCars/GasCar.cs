﻿using System;
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
        public float FuelConsuption { get; set; }
        

        public GasCar(Brand brand, BodyCar typeCar, Engine engine, int price, string number, string color, string model, int minSpeed, int maxSpeed, int weigtht,//base
           int tankCapacity, float fuelConsuption) : base(brand, typeCar, engine, price, number, color, model, minSpeed, maxSpeed, weigtht)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsuption = fuelConsuption;
        }
        public override void SortByFuelConsumption(ICollection<Car> cars)
        {
            ICollection<GasCar> gasCars = new List<GasCar>();

            if (cars.Count == 0)
            {
                //Nothing to sort
            }

            foreach (Car car in cars)
            {
                if (car is GasCar)
                {
                    gasCars.Add(car as GasCar);
                }
            }
            var resultGasCars = from i in gasCars
                                orderby i.FuelConsuption
                                select i;
            List<Car> result = new List<Car>();
            result.AddRange(resultGasCars);

        }
    }
}
