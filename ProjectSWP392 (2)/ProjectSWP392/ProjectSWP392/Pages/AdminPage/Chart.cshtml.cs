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
    public class Chart : PageModel
    {
        private readonly ILogger<Chart> _logger;
        private readonly IAccountService _accountService;
        public Chart(ILogger<Chart> logger,IAccountService accountService)
        {
            _accountService = accountService;
            _logger = logger;
        }
        public double month1 {get;set;}
        public double month2 {get;set;}
        public double month3 {get;set;}
        public double month4 {get;set;}
        public double month5 {get;set;}
        public double month6 {get;set;}
        public double month7 {get;set;}
        public double month8 {get;set;}
        public double month9 {get;set;}
        public double month10 {get;set;}
        public double month11 {get;set;}
        public double month12 {get;set;}

        public List<Expense> MonthlyExpenses { get; set; }

        public async Task OnGet()
        {
            month1 = _accountService.moneywithmonth(1);
            month2 = _accountService.moneywithmonth(2);
            month3 = _accountService.moneywithmonth(3);
            month4 = _accountService.moneywithmonth(4);
            month5 = _accountService.moneywithmonth(5);
            month6 = _accountService.moneywithmonth(6);
            month7 = _accountService.moneywithmonth(7);
            month8 = _accountService.moneywithmonth(8);
            month9 = _accountService.moneywithmonth(9);
            month10 = _accountService.moneywithmonth(10);
            month11 = _accountService.moneywithmonth(11);
            month12 = _accountService.moneywithmonth(12);
            _logger.LogInformation("111111: "+month1);
            MonthlyExpenses = new List<Expense>
            {
                new Expense { Category = "January", Amount = month1 },
                new Expense { Category = "Feburary", Amount = month2 },
                new Expense { Category = "March", Amount = month3 },
                new Expense { Category = "April", Amount = month4 },
                new Expense { Category = "May", Amount = month5 },
                new Expense { Category = "June", Amount = month6 },
                new Expense { Category = "July", Amount = month7 },
                new Expense { Category = "August", Amount = month8 },
                new Expense { Category = "September", Amount = month9 },
                new Expense { Category = "October", Amount = month10 },
                new Expense { Category = "November", Amount = month11 },
                new Expense { Category = "December", Amount = month12 },
                // Thêm các mục khác
            };
        }

        public class Expense
        {
            public string Category { get; set; }
            public double Amount { get; set; }
        }
    }
}