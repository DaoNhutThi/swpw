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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly OrderDetailDAO _orderDetailDAO;

        public OrderDetailService(OrderDetailDAO orderDetailDAO)
        {
            _orderDetailDAO = orderDetailDAO;
        }
        public Task<List<OrderDetailAdminResponse>> GetOrderDetailHistoryAsync(int id){
            return _orderDetailDAO.GetOrderDetailAdminAsync(id);
        }
    }
}