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
    public class CartService : ICartService
    {
        private readonly CartDAO _cartDAO;

        public CartService(CartDAO cartDAO)
        {
            _cartDAO = cartDAO;
        }
        public Task AddToCartAsync(int proid , int userid)
        {
            return _cartDAO.CreateCartAsync(proid,userid);
        }
        public Task DeleteAsync(int id)
        {
            return _cartDAO.DeleteCartAsync(id);
        }
        public Task PlusAsync(int id)
        {
            return _cartDAO.PlusCartAsync(id);
        }
        public Task SubAsync(int id)
        {
            return _cartDAO.SubCartAsync(id);
        }
        public Task<List<CustomCart>> GetCartsAsync(int id)
        {
            return _cartDAO.GetCartsAsync(id);
        }
    }
}