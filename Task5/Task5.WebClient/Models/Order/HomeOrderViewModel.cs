using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Task5.WebClient.Models.Client;
using Task5.WebClient.Models.Product;

namespace Task5.WebClient.Models.Order
{
    public class HomeOrderViewModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateTime { get; set; }
        [Required]
        [Display(Name = "Name")]
        public ClientViewModel Client { get; set; }
        [Required]
        [Display(Name = "Product")]
        public ProductViewModel Product { get; set; }
    }
}