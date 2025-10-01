using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.DTOs.Account
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()+}{"":;'?/><,])(?!.*\s).*",
        ErrorMessage = "Invalid Password!")]
        public string Password { get; set; }

    }
}
