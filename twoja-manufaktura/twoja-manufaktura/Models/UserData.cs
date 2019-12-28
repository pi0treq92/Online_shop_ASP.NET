using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace twoja_manufaktura.Models
{
    public class UserData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string CodeAndCity { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-]+",
            ErrorMessage = "Nr telefonu nieprawidłowy")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Nieprawidłowy e-mail.")]
        public string Email { get; set; }
    }
}