using System.ComponentModel.DataAnnotations;
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

namespace ProjectSWP392.Pages.AdminPage
{
    public class OrderManagement : PageModel
    {
        private readonly ILogger<OrderManagement> _logger;

        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        [BindProperty]
        public Order Edit { get; set; }

        [BindProperty]
        public List<Cart> cart {get;set;}
        public List<Order> order {get;set;}
        public List<CustomCart> CartItems {get;set;}

        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderManagement(ILogger<OrderManagement> logger, IOrderService orderService,ICartService cartService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _cartService = cartService;
            _userService = userService;
            _orderService = orderService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> OnGet()
        {
            try{
                order = await _orderService.GetOrderAsync();
                return Page();
            }
            catch(Exception ex){
                _logger.LogError("Checkout:" + ex.Message);
                return RedirectToPage("../Index");
            }
        }
        public async Task<IActionResult> OnPostAsync(){
            await _orderService.GetOrderConfirmAsync(Edit.OrderID);
            return RedirectToPage("/AdminPage/OrderManagement");
        }
    }
}