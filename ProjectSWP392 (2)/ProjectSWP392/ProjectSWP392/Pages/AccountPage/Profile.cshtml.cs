using System.Net;
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
using Microsoft.AspNetCore.Http;
using BusinessObject.DTO;


namespace ProjectSWP392.Pages.AccountPage
{
    public class Profile : PageModel
    {
        private readonly ILogger<Profile> _logger;
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountView acc {get;set;} = new AccountView();
        public Profile(ILogger<Profile> logger, IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _accountService = accountService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> OnGet()
        {
            try{
                int userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserID") ?? 0;
                acc = await _accountService.GetProfile(userId);
                return Page();
            }
            catch(Exception ex){
                _logger.LogError("Error: "+ex.Message);
                return RedirectToPage("/Index");
            }
        }
    }
}