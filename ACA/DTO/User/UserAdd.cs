using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACA.DTO.User
{
    public class UserAdd
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [Compare("Email")]
        public string ConfirmEmail { get; set; }

        [Required]

        public string Password { get; set; }
        [Required]
        [Compare("Password")]

        public string ConfirmPassword { get; set; }

    }
}
