using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Models
{
    public class MailContent
    {
        [Required(ErrorMessage = "To field is required")]
        [EmailAddress(ErrorMessage = "Invalid email address in To field")]
        public string To { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Body is required")]
        public string Body { get; set; }
    }
}