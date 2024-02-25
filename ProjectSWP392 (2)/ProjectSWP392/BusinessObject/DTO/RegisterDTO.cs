using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Error: Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Error: Password is required")]
        [MinLength(6, ErrorMessage = "Error: Password must be at least 6 characters long")]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "Error: Password is required")]
        [MinLength(6, ErrorMessage = "Error: Password must be at least 6 characters long")]
        public string ReEnterPassword { get; set; }
        [Required(ErrorMessage = "Error: FullName is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Error: Phone is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Error: Address is required")]
        public string Address { get; set; }
    }
}