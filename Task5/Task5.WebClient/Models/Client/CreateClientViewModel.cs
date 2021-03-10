using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WebClient.Models.Client
{
    public class CreateClientViewModel
    {
        [Required(ErrorMessage = "Введите значение")]
        [Display(Name = "Имя")]
        [RegularExpression(@"^[A-Za-z]{2,50}", ErrorMessage = "Неверное занчение. Имя должно содержать только буквы")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 30 символов")]
        public string Name { get; set; }
    }
}