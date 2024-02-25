using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Error: Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Error: Password is required")]
        [MinLength(6, ErrorMessage = "Error: Password must be at least 6 characters long")]
        public string Password { get; set; }
    }
}