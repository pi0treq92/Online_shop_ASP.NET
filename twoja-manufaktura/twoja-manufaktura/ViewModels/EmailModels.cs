using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using twoja_manufaktura.Models;

namespace twoja_manufaktura.ViewModels
{
    public class PotwierdzenieZamowieniaEmail: Email
    {
        public string Do { get; set; }
        public decimal Koszt { get; set; }
        public int NumerZamowienia { get; set; }
        public string Adres { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string PhotoPath { get; set; }
    }
}