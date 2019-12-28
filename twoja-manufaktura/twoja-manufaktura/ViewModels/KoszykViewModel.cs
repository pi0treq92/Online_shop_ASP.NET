using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using twoja_manufaktura.Models;

namespace twoja_manufaktura.ViewModels
{
    public class KoszykViewModel
    {
        public List<ItemKoszyk> KoszykItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}