using System.Net;
using System.Reflection;
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
using Microsoft.AspNetCore.Http;


namespace ProjectSWP392.Pages.AccountPage
{
    public class Login : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IAccountService _accountService;

        [BindProperty]
        public LoginDTO account { get; set; }
        public StorgeUser sto { get; set; }
        public Login(ILogger<Index> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public void OnGet()
        {
            HttpContext.Session.Clear();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool check = await _accountService.LoginAsync(account.Email, account.Password);
            sto = await _accountService.GetAccByEmailAsync(account.Email);
            if (check)
            {
                if(sto.isVerified == false){
                    TempData["Veri"] = "Ok";
                    return Page();
                }
                if(sto.AccountStatus == "0"){
                    TempData["Ban"] = "Ok";
                    return Page();
                }
                _logger.LogInformation($"Login successfully with {account.Email} and {account.Password}");
                HttpContext.Session.SetString("FullName",sto.FullName);
                HttpContext.Session.SetString("Admin",sto.Admin.ToString());
                HttpContext.Session.SetInt32("AccountID",sto.AccountID);
                HttpContext.Session.SetInt32("UserID",sto.UserID);
                if(sto.Admin == true){
                    TempData["Success"] = "Ok";
                }
                else{
                    TempData["SuccessUser"] = "Ok";
                }
            }else{
                _logger.LogError($"ThanhHuy {account.Email} and {account.Password}");
                TempData["LoginFail"] = "Error: Email or Password was wrong !!!";
            }
            return Page();
        }
    }
}
