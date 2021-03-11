using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WebClient.Models.Filters
{
    public class OrderFilter
    {
        [DataType(DataType.Date)]
        [Display(Name ="Дата")]
        public DateTime DateTime { get; set; }
        [Display(Name ="Имя")]
        public string ClientName { get; set; }
        [Display(Name ="Продукт")]
        public string ProductName { get; set; }
    }
}