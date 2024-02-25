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
    public class ProductDAO
    {
        private readonly DBContext _dbContext;
        public List<Product> prod { get; set; } = new List<Product>();
        public Product product { get; set; } = new Product();

        public ProductDAO(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            prod = await _dbContext.Products.Where(c => c.ProductStatus == "1").ToListAsync();
            return prod;
        }
        public async Task<List<Product>> GetAllProductByName(string searchInput)
        {
            string pro = searchInput.Trim();
            prod = await _dbContext.Products.Where(c => c.ProductStatus == "1" && c.ProductName.Contains(pro)).ToListAsync();
            return prod;
        }
        public async Task<List<Product>> GetAllProductByCate(int id)
        {
            prod = await _dbContext.Products.Where(c => c.ProductStatus == "1" && c.CategoryID == id).ToListAsync();
            return prod;
        }
         public async Task AddProduct(ProductDTO account)
        {
            int count = _dbContext.Products.ToList().Count();
            if (count == 0)
            {
                product.ProductID = 0;
            } else 
            {
                count++;
                product.ProductID = count;
            }
            product.ProductName = account.ProductName;
            product.ProductImage = account.ProductImage;
            product.ProductPrice = account.ProductPrice;
            product.CategoryID = account.CategoryID;
            product.ProductQuantity = account.ProductQuantity;
            product.ProductDetailDescription = account.ProductDetailDescription;
            product.ProductChipset = account.ProductChipset;
            product.ProductStorageInternal = account.ProductStorageInternal;
            product.ProductStorageExternal = account.ProductStorageExternal;
            product.ProductBatteryCapacity = account.ProductBatteryCapacity;
            product.ProductSelfieCamera = account.ProductSelfieCamera;
            product.ProductMainCamera = account.ProductMainCamera;
            product.ProductStatus = "1";
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Product> GetProductById(int Id)
        {
            product = await _dbContext.Products.Where(c => c.ProductID == Id).SingleOrDefaultAsync();
            return product;
        }
        public async Task UpdateProduct( int id,ProductDTO account)
        {
            product = await _dbContext.Products.Where(a => a.ProductID == id).SingleOrDefaultAsync();
            if (product == null)
            {
                throw new Exception("exist");
            }
            product.ProductName = account.ProductName;
            product.ProductImage = account.ProductImage;
            product.CategoryID = account.CategoryID;
            product.ProductPrice = account.ProductPrice;
            product.ProductQuantity = account.ProductQuantity;
            product.ProductDetailDescription = account.ProductDetailDescription;
            product.ProductChipset = account.ProductChipset;
            product.ProductStorageInternal = account.ProductStorageInternal;
            product.ProductStorageExternal = account.ProductStorageExternal;
            product.ProductBatteryCapacity = account.ProductBatteryCapacity;
            product.ProductSelfieCamera = account.ProductSelfieCamera;
            product.ProductMainCamera = account.ProductMainCamera;
            product.ProductStatus = "1";
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteProduct(int id)
        {
            product = await _dbContext.Products.Where(a => a.ProductID == id).SingleOrDefaultAsync();
            // if (product == null)
            // {
            //     throw new Exception("exist");
            // }
            product.ProductStatus = "0";
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}