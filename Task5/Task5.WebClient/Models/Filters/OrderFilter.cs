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
        [Display(Name ="Date")]
        public DateTime DateTime { get; set; }
        [Display(Name ="Name")]
        public string ClientName { get; set; }
        [Display(Name ="Product")]
        public string ProductName { get; set; }
    }
}