using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CookieAuthentication.Models
{
    public class LoginView
    {
        [Required(ErrorMessage = "Enter email")] 
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }
}