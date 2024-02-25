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
    public class CategoryManagement : PageModel
    {
        private readonly ICategoryService _categoryService;
        public List<Category> cates { get; set; } = new List<Category>();
        [BindProperty]
        public CategoryDTO regist { get; set; }        
        [BindProperty]
        public Category Edit { get; set; }
        private readonly ILogger<CategoryManagement> _logger;

        public CategoryManagement(ILogger<CategoryManagement> logger,ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            cates = await _categoryService.GetCategory();
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
                regist.CategoryId = Edit.CategoryId;
                regist.CategoryName = Edit.CategoryName;
                await _categoryService.DeleteCate(regist);
                _logger.LogInformation("User registered successfully");
                return RedirectToPage("/AdminPage/CategoryManagement");
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