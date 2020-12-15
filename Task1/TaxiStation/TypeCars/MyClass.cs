using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiStation.TypeCars
{
    class MyClass
    {
        public int a { get; set; }
        public int b { get; set; }
        public void Do(MyClass myClass)
        {

        }
        public void To()
        {
            Do(new MyClass() { a = 1, b=2});
        }
    }
}
