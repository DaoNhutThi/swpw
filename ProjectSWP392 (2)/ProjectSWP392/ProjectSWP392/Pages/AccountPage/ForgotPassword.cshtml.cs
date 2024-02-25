using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BusinessObject.Models;
using Repository.IService;
using Repository.Service;
using BusinessObject.DTO;

namespace ProjectSWP392.Pages.AccountPage
{
    public class ForgotPassword : PageModel
    {
        private readonly ILogger<ForgotPassword> _logger;
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;

        [BindProperty]
        public RegisterDTO regist { get; set; }
        public StorgeUser user { get; set; } = new StorgeUser();
        public ForgotPassword(ILogger<ForgotPassword> logger, IAccountService accountService, IEmailService emailService)
        {
            _logger = logger;
            _accountService = accountService;
            _emailService = emailService;
        }
        [BindProperty]
        public string Email {get;set;}
        public void OnGet()
        {
        }
        public async Task OnPostAsync()
        {
            try{
                string newpass = await _accountService.ForgotAsync(Email);
                MailContent mailContent = new MailContent()
                {
                    Subject = "ForgotPassword! Please sign in again!",
                    To = Email,
                    Body = "<!DOCTYPE html>\r\n<html>\r\n\r\n<head>\r\n  " +
                    "  <title>ForgotPassword Success</title>\r\n    <style>\r\n  " +
                    "      /* Define styles for the email */\r\n        body {\r\n         " +
                    "   font-family: Arial, sans-serif;\r\n            background-color: #f2f2f2;\r\n      " +
                    "      margin: 0;\r\n            padding: 0;\r\n        }\r\n\r\n        .container {\r\n      " +
                    "      max-width: 600px;\r\n            margin: 0 auto;\r\n            padding: 20px;\r\n          " +
                    "  background-color: #ffffff;\r\n            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);\r\n          " +
                    "  border-radius: 5px;\r\n        }\r\n\r\n        .header {\r\n            background-color: #4285f4;\r\n       " +
                    "     color: #ffffff;\r\n            text-align: center;\r\n            padding: 20px;\r\n            border-radius: 5px 5px 0 0;\r\n  " +
                    "      }\r\n\r\n        h1 {\r\n            font-size: 24px;\r\n            margin: 0;\r\n        }\r\n\r\n        .content {\r\n         " +
                    "   padding: 20px;\r\n            color: #333;\r\n        }\r\n\r\n        p {\r\n            font-size: 16px;\r\n            margin: 10px 0;\r\n   " +
                    "     }\r\n\r\n        .footer {\r\n            text-align: center;\r\n            background-color: #f2f2f2;\r\n            padding: 10px;\r\n        " +
                    "    border-radius: 0 0 5px 5px;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body>\r\n    <div class=\"container\">\r\n        <div class=\"header\">\r\n   " +
                    "         <h1>ForgotPassword Success</h1>\r\n        </div>\r\n        <div class=\"content\">\r\n                  <p>Your password has been successfully changed. You can now use your new password:<strong>{{newpass}}</strong> to access your account.</p>\r\n  " +
                    "      </div>\r\n        <div class=\"footer\">\r\n            <p>&copy; 2023 Your Company. All rights reserved.</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n\r\n</html>\r\n"
                };

                mailContent.Body = mailContent.Body.Replace("{{newpass}}", newpass);
                _emailService.SendMail(mailContent);
                TempData["Success"] = "Ok";
            }
            catch(Exception ex){
                TempData["Error"] = "Ok";
                _logger.LogError("Error: "+ex.Message);
            }
        }
    }
}