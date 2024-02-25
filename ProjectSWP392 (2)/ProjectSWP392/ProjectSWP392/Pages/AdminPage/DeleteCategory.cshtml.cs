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
    public class DeleteCategory : PageModel
    {
        private readonly ILogger<DeleteCategory> _logger;
        private readonly ICategoryService _categoryService;
        [BindProperty]
        public CategoryDTO regist { get; set; }        
        [BindProperty]
        public Category Edit { get; set; }
        public DeleteCategory(ILogger<DeleteCategory> logger,ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        public async Task OnGet(int Id)
        {
            ModelState.Clear();
            Edit = await _categoryService.GetCategoryId(Id);
            if (Edit == null)
            {
                Edit = await _categoryService.GetCategoryId(Id);
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