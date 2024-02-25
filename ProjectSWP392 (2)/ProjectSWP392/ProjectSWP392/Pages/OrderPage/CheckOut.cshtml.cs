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

namespace ProjectSWP392.Pages.OrderPage
{
    public class CheckOut : PageModel
    {
        private readonly ILogger<CheckOut> _logger;
        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        [BindProperty]
        public List<Cart> cart {get;set;}
        public User user {get;set;}
        public List<CustomCart> CartItems {get;set;}

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CheckOut(ILogger<CheckOut> logger, IOrderService orderService,ICartService cartService, IUserService userService, IHttpContextAccessor httpContextAccessor)
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
                int userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserID") ?? 0;
                CartItems = await _cartService.GetCartsAsync(userId);
                user = await _userService.GetUserByIdAsync(userId);
                return Page();
            }
            catch(Exception ex){
                _logger.LogError("Checkout:" + ex.Message);
                return RedirectToPage("../Index");
            }
        }
        public async Task OnGetCheckoutConfirm()
        {
            try{
                int userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserID") ?? 0;
                await _orderService.CreateOrderAsync(userId);
                TempData["Purcharse"] = "oK";
            }
            catch(Exception ex){
                _logger.LogError("Checkout:" + ex.Message);
            }
        }
    }
}