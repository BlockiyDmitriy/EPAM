using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Domain.Models
{
    public class StructFile
    {
        public int Id { get; private set; }
        public string Date { get; private set; }
        public string Client { get; private set; }
        public string Product { get; private set; }
        public int Sum { get; private set; }
    }
}
