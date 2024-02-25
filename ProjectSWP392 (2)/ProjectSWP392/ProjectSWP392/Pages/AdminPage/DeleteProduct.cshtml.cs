using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repository.IService;
using Repository.Service;


namespace ProjectSWP392.Pages.AdminPage
{
    public class DeleteProduct : PageModel
    {
        private readonly ILogger<DeleteProduct> _logger;
        private readonly IProductService _productService;
        [BindProperty]
        public ProductDTO regist { get; set; }        
        [BindProperty]
        public Product Edit { get; set; }
        public DeleteProduct(ILogger<DeleteProduct> logger,IProductService productService)
        {
            _productService = productService;
            _logger = logger;
        }
        public async Task OnGet(int Id)
        {
            ModelState.Clear();
            Edit = await _productService.GetProductId(Id);
            if (Edit == null)
            {
                Edit = await _productService.GetProductId(Id);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // if (!ModelState.IsValid)
                // {
                //     return Page();
                // }

                await _productService.DeleteProd(Edit.ProductID);
                

                _logger.LogInformation("User registered successfully");
                return RedirectToPage("/AdminPage/ProductManagement");
            }
            catch (Exception e)
            {
                _logger.LogError($"User registration failed: {e.Message}");
                TempData["RegistFail"] = $"User registration failed: {e.Message}";
                return Page();
            }
        }
    }
}