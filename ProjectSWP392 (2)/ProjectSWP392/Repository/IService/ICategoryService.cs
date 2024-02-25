using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;

namespace Repository.IService
{
    public interface ICategoryService
    {
         Task<List<Category>> GetCategory();
         Task<Category> GetCategoryId(int Id);
         Task AddCate(CategoryDTO account);
         Task EditCate(CategoryDTO account);
         Task DeleteCate(CategoryDTO account);
    }
}