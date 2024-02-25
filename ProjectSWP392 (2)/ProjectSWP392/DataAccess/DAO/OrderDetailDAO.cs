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
    public class OrderDetailDAO
    {
        private readonly DBContext _dbContext;
        
        public User user { get; set; } = new User();
        public Product product { get; set; } = new Product();
        public Order order1 { get; set; } = new Order();
        public OrderDetail orderdetail { get; set; }
        public List<OrderDetailAdminResponse> orderdetailadminresponses { get; set; } = new List<OrderDetailAdminResponse>();
        public List<OrderDetail> orderdetails { get; set; }
        
        public OrderDetailDAO(DBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<OrderDetailAdminResponse>> GetOrderDetailAdminAsync(int id)
        {
            orderdetails = await _dbContext.OrderDetails.Where(c => c.OrderDetailStatus == "1" && c.OrderID == id).ToListAsync();
            foreach (var order in orderdetails)
            {
                user = _dbContext.Users.Where(u => u.UserID == order.UserID).SingleOrDefault();
                order1 = _dbContext.Orders.Where(v => v.OrderID == order.OrderID).SingleOrDefault();
                product = _dbContext.Products.Where(c => c.ProductID == order.ProductID).SingleOrDefault();
                OrderDetailAdminResponse orderdetailAdminResponse = new OrderDetailAdminResponse()
                {
                    OrderID = order1.OrderID,
                    FullName = user.FullName,
                    Phone = user.Phone,
                    Address = user.Address,
                    OrderDate = order1.OrderDate,
                    OrderQuantity = order1.OrderQuantity,
                    OrderNote = order1.OrderNote,
                    ShipperDate = order1.ShipperDate,
                    ProductName = product.ProductName,
                    ProductImage = product.ProductImage,
                    ProductPrice = product.ProductPrice,
                    ProductQuantity = order.OrderDetailQuantity,
                    OrderDetailTotalPrice = order.OrderDetailTotalPrice

                };
                orderdetailadminresponses.Add(orderdetailAdminResponse);
            }

            return orderdetailadminresponses;
        }
    }
}