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

namespace ProjectSWP392.Pages.AdminPage
{
    public class DetailsProduct : PageModel
    {
        private readonly ILogger<DetailsProduct> _logger;
        private readonly IProductService _productService;
        [BindProperty]
        public ProductDTO regist { get; set; }        
        [BindProperty]
        public Product Edit { get; set; }
        private readonly ICategoryService _caService;
        public List<Category> categories { get; set; } = new List<Category>();
        public DetailsProduct(ILogger<DetailsProduct> logger,IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _caService = categoryService;
            _logger = logger;
        }
        public async Task OnGet(int Id)
        {
            categories = await _caService.GetCategory();
            Edit = await _productService.GetProductId(Id);
        }
       
    }
}