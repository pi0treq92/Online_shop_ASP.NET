﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoja_manufaktura.Models
{
    public class ItemKoszyk
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}