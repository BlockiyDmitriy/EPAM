﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task5.WebClient.Models.Order
{
    public class EditOrderViewModel
    {
        public int id { get; set; }
        public DateTime DateTime { get; set; }
        public string ClientName { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}