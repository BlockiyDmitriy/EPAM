using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.BLL.CSVParsing
{
    public class CSVDTO
    {
        public DateTime DateTime { get; set; }
        public string ClientName { get; set; }
        public string Product { get; set; }
        public double Sum { get; set; }
    }
}
