using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoja_manufaktura.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //IconFileName nazwa ikony wyświetlana obok gatunku genre
        public string IconFileName { get; set; }
        public virtual ICollection<Product> Products { get; set; } 
    }
}