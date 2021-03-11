using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WebClient.Models.Client
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Введите значение")]
        [RegularExpression(@"^[A-Za-z]{2,50}", ErrorMessage = "Неверное занчение. Имя должно содержать только буквы")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        [Display(Name="Имя")]
        public string Name { get; set; }
    }
}