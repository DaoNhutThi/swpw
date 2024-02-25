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
    public class OrderDetailHistory : PageModel
    {
        private readonly ILogger<OrderDetailHistory> _logger;

        private readonly ICartService _cartService;
        private readonly IUserService _userService;
        private readonly IOrderDetailService _orderDetailService;

        [BindProperty]
        public List<Cart> cart {get;set;}
        public User user {get;set;}
        public List<OrderDetailAdminResponse> order {get;set;}
        public List<CustomCart> CartItems {get;set;}

        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderDetailHistory(ILogger<OrderDetailHistory> logger, IOrderDetailService orderDetailService,ICartService cartService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _cartService = cartService;
            _userService = userService;
            _orderDetailService = orderDetailService;
            _httpContextAccessor = httpContextAccessor;
        }

       public async Task<IActionResult> OnGet(int orderid)
        {
            try{
                order = await _orderDetailService.GetOrderDetailHistoryAsync(orderid);
                user = await _userService.GetUserByNameAsync(order[0].FullName);
                return Page();
            }
            catch(Exception ex){
                _logger.LogError("Checkout:" + ex.Message);
                return RedirectToPage("../Index");
            }
        }
    }
}