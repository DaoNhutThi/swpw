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
    public class EditProduct : PageModel
    {
       private readonly ILogger<EditProduct> _logger;
        private readonly IProductService _productService;
        [BindProperty]
        public ProductDTO regist { get; set; }        
        [BindProperty]
        public Product Edit { get; set; }
        private readonly ICategoryService _caService;
        public List<Category> categories { get; set; } = new List<Category>();

        public EditProduct(ILogger<EditProduct> logger,IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _caService = categoryService;
            _logger = logger;
        }
        public async Task OnGet(int Id)
        {
            TempData["ProID"] = Id;
            categories = await _caService.GetCategory();
            Edit = await _productService.GetProductId(Id);
        }
         public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // if (!ModelState.IsValid)
                // {
                //     return Page();
                // }
                _logger.LogError("Acc: "+Edit);
                regist.ProductName = Edit.ProductName;
                regist.ProductPrice = Edit.ProductPrice;
                regist.ProductImage = Edit.ProductImage;
                regist.CategoryID = Edit.CategoryID;
                regist.ProductQuantity = Edit.ProductQuantity;
                regist.ProductDetailDescription = Edit.ProductDetailDescription;
                regist.ProductChipset = Edit.ProductChipset;
                regist.ProductStorageInternal = Edit.ProductStorageInternal;
                regist.ProductStorageExternal = Edit.ProductStorageExternal;
                regist.ProductBatteryCapacity = Edit.ProductBatteryCapacity;
                regist.ProductSelfieCamera = Edit.ProductSelfieCamera;
                regist.ProductMainCamera = Edit.ProductMainCamera;
                await _productService.EditProd(Edit.ProductID, regist);
                _logger.LogInformation("User registered successfully");
                return RedirectToPage("/AdminPage/ProductManagement");
            }
            catch (Exception e)
            {
                _logger.LogError($"User registration failed: {e.Message}");
                TempData["ProID"] = Edit.ProductID;
                TempData["RegistFail"] = $"User registration failed: {e.Message}";
                return Page();
            }
        }
    }
}