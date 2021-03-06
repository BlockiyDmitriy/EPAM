﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WebClient.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name ="Продукт")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Сумма")]
        public double Sum { get; set; }
    }
}