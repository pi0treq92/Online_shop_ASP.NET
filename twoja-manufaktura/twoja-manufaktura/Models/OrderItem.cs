using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoja_manufaktura.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        //Foreign Key Product
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        

    }
}