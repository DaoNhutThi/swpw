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
    public class AddProduct : PageModel
    {
       private readonly ILogger<AddProduct> _logger;
        private readonly IProductService _productService;
        private readonly ICategoryService _caService;
        public List<Category> categories { get; set; } = new List<Category>();
        [BindProperty]
        public ProductDTO regist { get; set; }
        public AddProduct(ILogger<AddProduct> logger,IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _caService = categoryService;
            _logger = logger;
        }
         public async Task OnGetAsync()
        {
            categories = await _caService.GetCategory();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                await _productService.AddProd(regist);
                _logger.LogInformation("User registered successfully");
                TempData["RegistFail"] = "Add product successfully";
                return RedirectToPage("/AdminPage/ProductManagement!!");
            }
            catch (Exception e)
            {
                _logger.LogError($"User registration failed: {e.Message}");
                TempData["RegistFail"] = "Add product failed!!";
                return Page();
            }
        }
    }
}