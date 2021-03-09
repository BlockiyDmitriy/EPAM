using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task5.WebClient.Models.Filters
{
    public class ClientFilter
    {
        [Display(Name ="Name")]
        public string Name { get; set; }
    }
}