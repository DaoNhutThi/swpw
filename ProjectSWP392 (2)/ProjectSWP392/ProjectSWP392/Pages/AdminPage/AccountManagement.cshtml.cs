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

namespace ProjectSWP392.Pages.AdminPage
{
    public class AccountManagement : PageModel
    {
        private readonly ILogger<AccountManagement> _logger;
        private readonly IAccountService _accountService;
        [BindProperty]
        public AccountView regist { get; set; }
        public List<AccountView> regists { get; set; }
        [BindProperty]
        public Account Edit { get; set; }
        public AccountManagement(ILogger<AccountManagement> logger,IAccountService accountService)
        {
            _accountService = accountService;
            _logger = logger;
        }
        public async Task OnGet()
        {
            regists= await _accountService.LoadAsync();
        }
        public async Task OnGetPer(int Id)
        {
            _logger.LogError("Handler success" + Id);
            try{
                await _accountService.ChangePerAsync(Id);
                regists= await _accountService.LoadAsync();
                TempData["Persuccess"]= "Yes";
            }
            catch(Exception ex){
                _logger.LogError("Lỗi:" + ex.Message);
            }
        }
        public async Task<IActionResult> OnPostAsync(){
            await _accountService.BanAsync(Edit.AccountID);
            return RedirectToPage("/AdminPage/AccountManagement");
        }
    }
}