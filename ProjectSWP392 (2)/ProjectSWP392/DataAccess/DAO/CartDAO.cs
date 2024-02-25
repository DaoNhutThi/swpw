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
    public class CartDAO
    {
        private readonly DBContext _dbContext;
        public Product product { get; set; } = new Product();
        public Cart cart { get; set; } = new Cart();
        public List<Cart> carts { get; set; }
        public User user { get; set; }
        public List<CustomCart> customCart {get;set;} = new List<CustomCart>();

        public CartDAO(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CustomCart>> GetCartsAsync(int id)
        {
            var carts = await _dbContext.Carts.Where(c => c.UserID == id && c.CartStatus == "1").ToListAsync();
            foreach(var cart in carts)
            {
                product = _dbContext.Products.Where(u => u.ProductID == cart.ProductID).FirstOrDefault();
                var cusCart = new CustomCart()
                {
                    CartId = cart.CartId,
                    CartQuantity = cart.CartQuantity,
                    ProductName = product.ProductName,
                    ProductImage = product.ProductImage,
                    Price = cart.Price
                };
                customCart.Add(cusCart);
            }
            return customCart;
        }
        public async Task CreateCartAsync(int proid, int userid)
        {
            try
            {
                product = await _dbContext.Products
                    .Where(c => c.ProductID == proid)
                    .SingleOrDefaultAsync();

                user = await _dbContext.Users
                    .Where(c => c.UserID == userid)
                    .SingleOrDefaultAsync();

                int count = await _dbContext.Carts.CountAsync();

                if (count == 0)
                {
                    cart.CartId = 1;
                }
                else
                {
                    cart.CartId = count + 1;
                }

                cart.UserID = user.UserID;
                cart.ProductID = product.ProductID;
                cart.ProductName = product.ProductName;
                cart.CartQuantity = 1;
                cart.ProductImage = product.ProductImage;
                cart.Price = product.ProductPrice * cart.CartQuantity;
                cart.CartStatus = "1";

                await UpdateCart(cart);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("AddCartFail"+ex.Message);
            }
        }

        public async Task UpdateCart(Cart cart)
        {
            var userCart = await _dbContext.Carts
                .Where(c => c.UserID == cart.UserID && c.ProductID == cart.ProductID && c.CartStatus == "1")
                .FirstOrDefaultAsync();

            if (userCart != null)
            {
                int temp = userCart.CartQuantity;
                double tempprice = userCart.Price / temp;
                userCart.CartQuantity = userCart.CartQuantity + 1;
                userCart.Price = tempprice * userCart.CartQuantity;
                _dbContext.Carts.Update(userCart);
            }
            else
            {
                await _dbContext.Carts.AddAsync(cart);
            }

            await _dbContext.SaveChangesAsync();
        }
        public async Task PlusCartAsync(int id)
        {
            var cart = _dbContext.Carts.SingleOrDefault(c => c.CartId == id);
            var pro = _dbContext.Products.SingleOrDefault(c => c.ProductID == cart.ProductID);
            if (cart != null)
            {
                int temp = cart.CartQuantity;
                double tempprice = cart.Price / temp;
                if(cart.CartQuantity == pro.ProductQuantity){
                    throw new Exception("notenough");
                }
                cart.CartQuantity = cart.CartQuantity + 1;
                cart.Price = tempprice * cart.CartQuantity;
                _dbContext.Carts.Update(cart);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("plus");
            }
        }
        public async Task SubCartAsync(int id)
        {
            var cart = _dbContext.Carts.SingleOrDefault(c => c.CartId == id);

            if (cart != null)
            {
                int temp = cart.CartQuantity;
                double tempprice = cart.Price / temp;
                cart.CartQuantity = cart.CartQuantity - 1;
                cart.Price = tempprice * cart.CartQuantity;
                if (cart.CartQuantity <= 0)
                {
                    cart.CartStatus = "0";
                    _dbContext.Carts.Update(cart);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    _dbContext.Carts.Update(cart);
                    await _dbContext.SaveChangesAsync();
                }
              
            }
            else
            {
                throw new Exception("sub");
            }
        }
        public async Task DeleteCartAsync(int id)
        {
            var cart = await _dbContext.Carts.Where(c => c.CartId == id).SingleOrDefaultAsync();

            if (cart != null)
            {
                cart.CartStatus="0";
                _dbContext.Carts.Update(cart);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("deletecartfail");
            }    
        }
    }

}