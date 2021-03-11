using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WebClient.Models.Filters
{
    public class ProductFilter
    {
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Сумма")]
        public double Sum { get; set; }
    }
}