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
    public class changePassModel : PageModel
    {
         private readonly ILogger<Profile> _logger;
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public ChangePassView acc { get; set; } 
        public changePassModel(ILogger<Profile> logger, IAccountService accountService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _accountService = accountService;
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
                    
            if(!ModelState.IsValid){
                return Page();
            }
            try
            {
                
                    int userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserID") ?? 0;
                    
                    await _accountService.ChangePass(acc, userId);
                    return RedirectToPage("/AccountPage/Profile");
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.Message);
                return RedirectToPage("/Index");
            }
        }
    }
}
