using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WebClient.Models.Order
{
    public class EditOrderViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [DataType(DataType.Date)]
        [Display(Name ="Дата")]
        public DateTime DateTime { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Имя")]
        public string ClientName { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Продукт")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Введите значение")]
        [Min(0, ErrorMessage = "Значение не должно быть меньше 0")]
        [Display(Name = "Сумма")]
        public double Sum { get; set; }
    }
}