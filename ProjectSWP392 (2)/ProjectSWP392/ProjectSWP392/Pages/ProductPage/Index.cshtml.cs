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
using Microsoft.AspNetCore.Http.Extensions;
using BusinessObject.DTO;

namespace ProjectSWP392.Pages.ProductPage
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;
        private readonly IProductService _dbcontext;
        private readonly ICategoryService _categoryService;

        public Index(ILogger<Index> logger , IProductService dBContext, ICategoryService categoryService)
        {
            _logger = logger;
            _dbcontext = dBContext;
            _categoryService = categoryService;
        }
        public List<Product> product {get;set;}
        public List<Category> categories {get;set;}
        public async Task OnGet()
        {
            product = await _dbcontext.GetProduct();
            categories = await _categoryService.GetCategory();
        }
        public async Task OnPostSearch(string searchInput)
        {
            _logger.LogError("Search: " + searchInput);
            product = await _dbcontext.GetProductByName(searchInput);
            categories = await _categoryService.GetCategory();
        }
        public async Task OnGetCate(int id)
        {
            product = await _dbcontext.GetProductByCate(id);
            categories = await _categoryService.GetCategory();
        }
    }
}