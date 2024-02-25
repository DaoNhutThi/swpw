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
    public class ConfirmOrder : PageModel
    {
        private readonly ILogger<ConfirmOrder> _logger;
        private readonly IOrderService _orderService;
        [BindProperty]
        public CategoryDTO regist { get; set; }        
        [BindProperty]
        public Order Edit { get; set; }
        public ConfirmOrder(ILogger<ConfirmOrder> logger,IOrderService orderService)
        {
            _orderService = orderService;
            _logger = logger;
        }
        public async Task OnGet(int Id)
        {
            Edit = await _orderService.GetOrderIDAsync(Id);
            if (Edit == null)
            {
                Edit = await _orderService.GetOrderIDAsync(Id);
            }
        }
    }
}