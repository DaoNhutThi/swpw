using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessObject.DTO
{
    public class ChangePassView
    {
        [Required]
        public string OldPass { get; set; }
        [Required]
        public string NewPass { get; set; }
        [Required]
        [Compare("NewPass", ErrorMessage = "New password and confirmation must match.")]
        public string ConfirmPass { get; set; }
       
    }
}