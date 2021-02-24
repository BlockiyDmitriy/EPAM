 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task5.WebClient.Models.Client;
using Task5.WebClient.Models.Product;

namespace Task5.WebClient.Models.Order
{
    public class CreateOrderViewModel
    {
        public DateTime DateTime { get; set; }
        public ClientViewModel Client { get; set; }
        public ProductViewModel Product { get; set; }
    }
}