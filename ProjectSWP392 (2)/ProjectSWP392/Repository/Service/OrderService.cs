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
    public class OrderService : IOrderService
    {
        private readonly OrderDAO _orderDAO;

        public OrderService(OrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        public Task CreateOrderAsync(int userid)
        {
            return _orderDAO.CreateOrderAsync(userid);
        }

        public Task<List<Order>> GetOrderAsync()
        {
            return _orderDAO.GetOrderAsync();
        }
        public Task<List<Order>> GetOrderHistoryAsync(int id)
        {
            return _orderDAO.GetOrderHistoryAsync(id);
        }
        public Task GetOrderConfirmAsync(int id)
        {
            return _orderDAO.GetOrderConfirmAsync(id);
        }
        public Task<Order> GetOrderIDAsync(int id){
            return _orderDAO.GetOrderIDAsync(id);
        }
    }
}