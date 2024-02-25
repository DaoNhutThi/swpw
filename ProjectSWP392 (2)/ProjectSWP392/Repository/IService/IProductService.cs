using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;

namespace Repository.IService
{
    public interface IProductService
    {
        Task<List<Product>> GetProduct();
        Task<List<Product>> GetProductByName(string searchInput);
        Task<List<Product>> GetProductByCate(int id);
         Task<Product> GetProductId(int Id);
         Task AddProd(ProductDTO account);
         Task EditProd(int id,ProductDTO account);
         Task DeleteProd(int id);
    }
}