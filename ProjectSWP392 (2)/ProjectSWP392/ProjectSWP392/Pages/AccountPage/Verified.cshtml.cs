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
    public class Verified : PageModel
    {
        private readonly ILogger<Verified> _logger;
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;

        [BindProperty]
        public RegisterDTO regist { get; set; }
        public StorgeUser user { get; set; } = new StorgeUser();
        public Verified(ILogger<Verified> logger, IAccountService accountService, IEmailService emailService)
        {
            _logger = logger;
            _accountService = accountService;
            _emailService = emailService;
        }
        public async Task OnGet(int Id)
        {
                _logger.LogError("1111111111111111111111111111"+Id);
            try{
                await _accountService.VerifiedAsync(Id);
                _logger.LogError("1111111111111111111111111111");
            }
            catch(Exception ex){
                _logger.LogError("Error:" +ex.Message);
            }
        }
    }
}