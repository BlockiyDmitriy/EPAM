using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiStation.Enum;

namespace TaxiStation
{
    public abstract class Car
    {
        public Brand Brand { get; set; }
        public TypeCar Type { get; set; }

        public Engine Engine { get; set; }

        public int Price { get; set; }

        public string Model { get; set; }
        public int MinSpeed { get; set; }
        public int MaxSpeed { get; set; }

        public Car(Engine engine)
        {
            this.Engine = engine;
        }
    }
}
