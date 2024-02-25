using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using BusinessObject.Models;
using BusinessObject.DTO;

namespace DataAccess.DAO
{
    public class CategoryDAO
    {
        private readonly DBContext _dbContext;
        public List<Category> cates { get; set; } = new List<Category>();
        public Category category { get; set; } = new Category();

        public CategoryDAO(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Category>> GetAllCategory()
        {
            cates = await _dbContext.Categorys.Where(c => c.CategoryStatus == "1").ToListAsync();
            return cates;
        }
        public async Task AddCategory(CategoryDTO account)
        {
            int count = _dbContext.Categorys.ToList().Count();
            var check = await Task.Run(() =>
                _dbContext.Categorys.Where(a => a.CategoryId == account.CategoryId).ToList());
            if (check.Count > 0)
            {
                throw new Exception("exist");
            }
            category.CategoryId = account.CategoryId;
            category.CategoryName = account.CategoryName;
            category.CategoryStatus = "1";
            _dbContext.Categorys.Add(category);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Category> GetCategoryById(int Id)
        {
            category = await _dbContext.Categorys.Where(c => c.CategoryId == Id).SingleOrDefaultAsync();
            return category;
        }
        public async Task UpdateCategory(CategoryDTO account)
        {
            category = await _dbContext.Categorys.Where(a => a.CategoryId == account.CategoryId).SingleOrDefaultAsync();
            if (category == null)
            {
                throw new Exception("exist");
            }
            category.CategoryId = account.CategoryId;
            category.CategoryName = account.CategoryName;
            category.CategoryStatus = "1";
            _dbContext.Categorys.Update(category);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteCategory(CategoryDTO account)
        {
            category = await _dbContext.Categorys.Where(a => a.CategoryId == account.CategoryId).SingleOrDefaultAsync();
            if (category == null)
            {
                throw new Exception("exist");
            }
            category.CategoryId = account.CategoryId;
            category.CategoryName = account.CategoryName;
            category.CategoryStatus = "0";
            _dbContext.Categorys.Update(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}