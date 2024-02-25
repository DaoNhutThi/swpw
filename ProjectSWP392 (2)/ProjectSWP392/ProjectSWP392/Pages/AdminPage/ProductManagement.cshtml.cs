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
using BusinessObject.DTO;


namespace ProjectSWP392.Pages.AdminPage
{
    public class ProductManagement : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _caService;
        public List<Product> prod { get; set; } = new List<Product>();
        public List<Category> categories { get; set; } = new List<Category>();

        [BindProperty]
        public ProductDTO regist { get; set; }        
        [BindProperty]
        public Product Edit { get; set; }
        private readonly ILogger<ProductManagement> _logger;

        public ProductManagement(ILogger<ProductManagement> logger,IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _caService = categoryService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            categories = await _caService.GetCategory();
            prod = await _productService.GetProduct();
            return Page();
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