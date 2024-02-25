using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;
using DataAccess.DAO;
using Repository.IService;

namespace Repository.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryDAO _categoryDAO;

        public CategoryService(CategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }
        public Task<List<Category>> GetCategory()
        {
            return _categoryDAO.GetAllCategory();
        } 
        public Task AddCate(CategoryDTO account)
        {
              return _categoryDAO.AddCategory(account);
        }
        public  Task EditCate(CategoryDTO account)
        {
            return _categoryDAO.UpdateCategory(account);
        }
         public Task<Category> GetCategoryId(int Id)
        {
            return _categoryDAO.GetCategoryById(Id);
        } 
         public  Task DeleteCate(CategoryDTO account)
        {
            return _categoryDAO.DeleteCategory(account);
        }
    }
}