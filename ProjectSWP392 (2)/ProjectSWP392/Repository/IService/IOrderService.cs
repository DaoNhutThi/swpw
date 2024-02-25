using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;

namespace Repository.IService
{
    public interface IOrderService
    {
        public Task CreateOrderAsync(int userid);
        public Task<List<Order>> GetOrderAsync();
        public Task<Order> GetOrderIDAsync(int id);
        public Task<List<Order>> GetOrderHistoryAsync(int id);
        public Task GetOrderConfirmAsync(int id);
    }
}