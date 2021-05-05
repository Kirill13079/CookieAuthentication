using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CookieAuthentication.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
        public string Captcha { get; set; }

     
    }
}