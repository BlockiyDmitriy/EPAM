using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WebClient.Models.Product
{
    public class CreateProductViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        public double Sum { get; set; }
    }
}