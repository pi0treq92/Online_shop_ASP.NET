using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoja_manufaktura.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        //Foreign Key Kategoria
        public int KategoriaId { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; }
        public string PhotoFileName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsBestseller { get; set; }
        //pole ishidden umożliwia wyświetlenie produktów ze starych zamówień, zamiast usuwania ich z bazy danych
        public bool IsHidden { get; set; }
        //Właściwość nawigująca pozwalająca wyświetlić właściwości klucza obcego
        public virtual Kategoria Kategoria { get; set; }
    }
}