using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Enum;
using TaxiStation.Functionality;

namespace TaxiStation
{
    public abstract class Car : IHoursePowerPerTon
    {
        public Brand Brand { get; set; }
        public BodyCar Type { get; set; }

        public Engine Engine { get; set; }

        public int Price { get; set; }
        public string Number { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public int MinSpeed { get; set; }
        public int MaxSpeed { get; set; }

        public int Weight { get; set; }


        public Car(Brand brand, BodyCar typeCar, Engine engine, int price, string number, string color, string model, int minSpeed, int maxSpeed, int weigtht)
        {
            this.Brand = brand;
            this.Type = typeCar;
            this.Engine = engine;
            this.Price = price;
            this.Number = number;
            this.Color = color;
            this.Model = model;
            this.MinSpeed = minSpeed;
            this.MaxSpeed = maxSpeed;
            this.Weight = weigtht;
        }
        public virtual void SortByFuelConsumption(ICollection<Car> cars)
        {
            throw new Exception();
        }
    }
}
