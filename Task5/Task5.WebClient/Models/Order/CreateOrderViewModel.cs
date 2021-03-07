 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task5.WebClient.Models.Client;
using Task5.WebClient.Models.Product;

namespace Task5.WebClient.Models.Order
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = "Введите значение")]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        [Required(ErrorMessage ="Введите значение")]
        [Display(Name ="Name")]
        public string Client { get; set; }
        [Required(ErrorMessage ="Введите значение")]
        [Display(Name = "Product")]
        public string Product { get; set; }

        public SelectList Clients;
        public SelectList Products;
    }
}