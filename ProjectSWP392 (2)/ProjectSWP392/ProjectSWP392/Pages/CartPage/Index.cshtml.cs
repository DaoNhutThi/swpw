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

namespace ProjectSWP392.Pages.CartPage
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly ICartService _cartService;
        [BindProperty]
        public List<Cart> cart {get;set;}
        public List<CustomCart> CartItems {get;set;}

        private readonly IHttpContextAccessor _httpContextAccessor;

        public Index(ILogger<Index> logger, ICartService cartService, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _cartService = cartService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task OnGet()
        {
            int userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserID") ?? 0;
            CartItems = await _cartService.GetCartsAsync(userId);
        }
        public async Task<IActionResult> OnGetAddToCartAsync(int proid, int userid)
        {
            try{
                _logger.LogError("Cart:"+proid+"/"+userid );
                await _cartService.AddToCartAsync(proid,userid);
                return RedirectToPage("Index");
            }
            catch(Exception ex){
                _logger.LogError("CartError:"+ex.Message);
                return Page(); 
            }
        }
        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            try{
                _logger.LogError("CartIDError:"+id);
                await _cartService.DeleteAsync(id);
                return RedirectToPage("Index");
            }
            catch(Exception ex){
                _logger.LogError("CartError:"+ex.Message);
                return Page(); 
            }
        }
        public async Task<IActionResult> OnGetPlusAsync(int id)
        {
            try{
                _logger.LogError("CartIDError:"+id);
                await _cartService.PlusAsync(id);
                return RedirectToPage("Index");
            }
            catch(Exception ex){
                _logger.LogError("CartError:"+ex.Message);
                if(ex.Message == "notenough"){
                    TempData["end"] = "OK";
                    int userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserID") ?? 0;
                    CartItems = await _cartService.GetCartsAsync(userId);
                    return Page();
                }
                return Page(); 
            }
        }
        public async Task<IActionResult> OnGetSubAsync(int id)
        {
            try{
                _logger.LogError("CartIDError:"+id);
                await _cartService.SubAsync(id);
                return RedirectToPage("Index");
            }
            catch(Exception ex){
                _logger.LogError("CartError:"+ex.Message);
                return Page(); 
            }
        }
    }
}