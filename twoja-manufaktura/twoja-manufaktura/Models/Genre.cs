using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoja_manufaktura.Models
{
    public class Kategoria
    {
        public int KategoriaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //IconFileName nazwa ikony wyświetlana obok gatunku kategoria
        public string IconFileName { get; set; }
        public virtual ICollection<Product> Products { get; set; } 
    }
}