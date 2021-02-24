using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Task5.WebClient.Models.Client;
using Task5.WebClient.Models.Product;

namespace Task5.WebClient.Models.Order
{
    public class DetailsOrderViewModel : HomeOrderViewModel
    {
        [Required]
        public ClientViewModel Client { get; set; }
        [Required]
        public ProductViewModel Product { get; set; }
    }
}