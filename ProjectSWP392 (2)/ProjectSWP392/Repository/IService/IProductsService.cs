using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;

namespace Repository.IService
{
    public interface IProductsService
    {
         Task<List<Product>> GetProduct();
         Task<Product> GetProductId(int Id);
         Task AddProd(ProductDTO account);
         Task EditProd(ProductDTO account);
         Task DeleteProd(ProductDTO account);
    }
}