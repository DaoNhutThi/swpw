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
    public class BanAcc : PageModel
    {
        private readonly ILogger<BanAcc> _logger;
        private readonly IAccountService _accountService;
        [BindProperty]
        public CategoryDTO regist { get; set; }        
        [BindProperty]
        public Account Edit { get; set; }
        public BanAcc(ILogger<BanAcc> logger,IAccountService accountService)
        {
            _accountService = accountService;
            _logger = logger;
        }
        public async Task OnGet(int Id)
        {
            Edit = await _accountService.GetAccByIdAsync(Id);
            if (Edit == null)
            {
                Edit = await _accountService.GetAccByIdAsync(Id);
            }
        }
    }
}