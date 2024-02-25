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
    public class DashBoard : PageModel
    {   
        private readonly IAccountService _accountService;
        private readonly ILogger<DashBoard> _logger;
        public int acc {get;set;}
        public int pro {get;set;}
        public int order {get;set;}
        public double reven {get;set;}

        public DashBoard(ILogger<DashBoard> logger,IAccountService accountService)
        {
            _accountService = accountService;
            _logger = logger;
        }

        public void OnGet()
        {
            acc = _accountService.CountAcc();
            pro = _accountService.CountPro();
            order = _accountService.CountOrder();
            reven = _accountService.money();
        }
    }
}