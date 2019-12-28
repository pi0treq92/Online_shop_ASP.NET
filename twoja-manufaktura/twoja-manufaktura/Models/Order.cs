using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace twoja_manufaktura.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Wprowadzony zły kod pocztowy")]
        public int Code { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public OrderState OrderState { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public enum OrderState
    {
        New,
        Shipped,
        Canceled
    }

}