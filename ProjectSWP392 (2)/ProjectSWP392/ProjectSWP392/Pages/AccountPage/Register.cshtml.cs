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
    public class Register : PageModel
    {
        private readonly ILogger<Register> _logger;
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;

        [BindProperty]
        public RegisterDTO regist { get; set; }
        public StorgeUser user { get; set; } = new StorgeUser();
        public Register(ILogger<Register> logger, IAccountService accountService, IEmailService emailService)
        {
            _logger = logger;
            _accountService = accountService;
            _emailService = emailService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await _accountService.RegisterAsync(regist);
                user = await _accountService.GetAccByEmailAsync(regist.Email);
                _logger.LogInformation("User registered successfully");
                var mailContent = new MailContent()
                {
                    Subject = "Register !! Verified email!!",
                    To = regist.Email,
                    Body = $@"<!DOCTYPE html>
                                <html lang=""en"">
                                <head>
                                    <meta charset=""UTF-8"" />
                                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                                    <title>Browser</title>
                                </head>
                                <body style=""margin: 0; padding: 0; background-color: #ffffff; display: flex; justify-content: center; align-items: center; height: 100vh;"">
                                    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" height=""50%"" style=""max-width: 500px;max-height: 500px; "" align=""center"">
                                        <tr>
                                            <td bgcolor=""aliceblue"" style=""padding: 25px; text-align: center;border-radius: 10px;"">
                                                <p style=""font-size: 18px; color: black;margin:0px !important;"">Hi you,</p>
                                                <p style=""font-size: 16px;color: black;"">We're happy you signed up for Phone Love. To start exploring the Phone Shop Website, please confirm your email address.</p>
                                                <a href=""https://localhost:5001/AccountPage/Verified?Id={user.AccountID}"" style=""background: #004aad; color: #fff; text-decoration: none; display: inline-block; width: 7rem; height: 2rem;padding-top: 0.3rem; line-height: 1.8rem; text-align: center; border-radius: 2rem; font-size: 14px;"">Verify now</a>
                                                <p style=""font-size: 18px;color: black;"">Welcome to Phone Love!</p>
                                            </td>
                                        </tr>
                                    </table>
                                </body>
                                </html>"
                };
                await _emailService.SendMail(mailContent);
                TempData["Ok"] = "Ok";
                return Page();
            }
            catch (Exception e)
            {
                if(e.Message == "email"){
                    TempData["Exist"] = $"User registration failed: {e.Message}";
                    return Page();
                }
                else if(e.Message == "Passnotmatch")
                {
                    TempData["Pass"] = "Ok";
                    return Page();
                }
                return Page();
            }
        }
    }
}
