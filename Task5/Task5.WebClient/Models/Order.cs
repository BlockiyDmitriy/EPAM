﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task5.WebClient.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}