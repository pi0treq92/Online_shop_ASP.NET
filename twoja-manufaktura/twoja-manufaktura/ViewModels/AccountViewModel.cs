using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace twoja_manufaktura.ViewModels
{
    public class LoginViewModel
    {
        //walidacja danych
        [Required(ErrorMessage = "Wprowadz poprawny email")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wprowadz haslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Haslo")]
        public string Password { get; set; }
        [Display(Name = "Pamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(20, ErrorMessage = "The {0} musi miec co najmniej {2} znakow", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Haslo roznia się")]
        public string ConfirmPassword { get; set; }
    }
}