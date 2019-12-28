using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using twoja_manufaktura.Models;

namespace twoja_manufaktura.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Bestsellers { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Product> NewArrivals { get; set; }
    }
}