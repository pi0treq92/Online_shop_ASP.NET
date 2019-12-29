using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace twoja_manufaktura.Models
{
    public class Order
    {
        //Utworzenie relacji zamowienie-user z wykorzystaniem ApplicationUser, UserId - klucz obcy
        //ApplicationUser wirtualna właściwość nawigacyjna, która pozwala z zamówienia przejść do ownera zamówienia - user
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int OrderId { get; set; }
        [Required(ErrorMessage ="Podaj imię")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj nazwisko")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Podaj adres")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Podaj miasto")]
        public string City { get; set; }
        [Required(ErrorMessage = "Wprowadzony zły kod pocztowy")]
        public int Code { get; set; }
        [StringLength(9)]
        [Required(ErrorMessage = "Podaj numer tel. np 123456789")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Podaj email")]
        [EmailAddress(ErrorMessage = "Błedny email")]
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