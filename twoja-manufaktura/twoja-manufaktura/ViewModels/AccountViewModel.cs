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
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Wprowadz haslo")]
        public string Password { get; set; }
        [Display(Name = "Pamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
    public class RegisterViewModel
    {
        //walidacja danych
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Wprowadz haslo")]
        [StringLength(50, ErrorMessage ="{0} musi miec co najmniej {2} znakow", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdz haslo")]
        [Compare("Password", ErrorMessage ="Haslo roznia się")]
        public bool ConfirmPassword { get; set; }
    }
}