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
    public class ProductService : IProductService
    {
        private readonly ProductDAO _productDAO;

        public ProductService(ProductDAO productDAO)
        {
            _productDAO = productDAO;
        }
        public Task<List<Product>> GetProduct()
        {
            return _productDAO.GetAllProduct();
        } 
        public Task<List<Product>> GetProductByName(string searchInput)
        {
            return _productDAO.GetAllProductByName(searchInput);
        } 

        public Task<List<Product>> GetProductByCate(int id)
        {
            return _productDAO.GetAllProductByCate(id);
        } 
        public Task AddProd(ProductDTO account)
        {
              return _productDAO.AddProduct(account);
        }
        public  Task EditProd(int id,ProductDTO account)
        {
            return _productDAO.UpdateProduct(id,account);
        }
         public Task<Product> GetProductId(int Id)
        {
            return _productDAO.GetProductById(Id);
        } 
         public  Task DeleteProd(int id)
        {
            return _productDAO.DeleteProduct(id);
        }
    }
}