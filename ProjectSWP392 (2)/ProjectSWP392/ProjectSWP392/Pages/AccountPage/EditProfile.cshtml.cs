using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repository.IService;

namespace ProjectSWP392.Pages.AccountPage
{
    public class EditProfileModel : PageModel
    {
        private readonly ILogger<Profile> _logger;
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EditProfileModel(ILogger<Profile> logger, IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _accountService = accountService;
            _httpContextAccessor = httpContextAccessor;
        }
        [BindProperty]
        public AccountView acc {get;set;}
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

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserID") ?? 0;
                    await _accountService.UpdateAccount(acc, userId);
                    return RedirectToPage("/AccountPage/Profile");
                }
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return RedirectToPage("/Index");
            }
        }
    }
}
