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
    public class OrderDAO
    {
        private readonly DBContext _dbContext;
        public User product { get; set; } = new User();
        public List<OrderDetail> orderdetail { get; set; } = new List<OrderDetail>();
        public Order order { get; set; } = new Order();
        public Product pro { get; set; } = new Product();
        public List<Order> orders { get; set; }
        public List<OrderAdminResponse> orderadminresponses { get; set; } = new List<OrderAdminResponse>();
        public OrderDetail ordersdetail { get; set; } = new OrderDetail(); 
        public List<Cart> cart { get; set; }
        public OrderDAO(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateOrderAsync(int userid)
        {
            cart = _dbContext.Carts.Where(C=> C.UserID == userid && C.CartStatus == "1").ToList();
            int countDetail = _dbContext.OrderDetails.ToList().Count();
            int countCart = cart.Count;
            int count = _dbContext.Orders.ToList().Count();
            if(count == 0) {
                order.OrderID = 1;
            }
            else
            {
                count++;
                order.OrderID = count;
            }
                order.UserID = userid;
                order.OrderDate = DateTime.Now;
                order.OrderQuantity = countCart;
                order.ShipperDate = DateTime.Now.AddDays(5);
                order.OrderNote = "Waiting for confirm";
                order.OrderStatus = "1";
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            foreach (var item in cart)
            {
                pro = _dbContext.Products.Where(p=> p.ProductID == item.ProductID).FirstOrDefault();
                var ordersdetail = new OrderDetail();
                if (countDetail == 0)
                {
                    ordersdetail.OrderDetailID = 1;
                }
                else
                {
                    ordersdetail.OrderDetailID = countDetail + 1;
                }
                ordersdetail.OrderDetailTotalPrice = item.Price;
                ordersdetail.OrderDetailQuantity = item.CartQuantity;
                ordersdetail.OrderID = order.OrderID;
                ordersdetail.ProductID = item.ProductID;
                ordersdetail.UserID = userid;
                ordersdetail.OrderDetailStatus = "1";
                _dbContext.OrderDetails.Add(ordersdetail);
                item.CartStatus = "0";
                _dbContext.Carts.Update(item);
                countDetail++;
                pro.ProductQuantity = pro.ProductQuantity - ordersdetail.OrderDetailQuantity;
                _dbContext.Products.Update(pro);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<List<Order>> GetOrderAsync()
        {
            var orders = await _dbContext.Orders.Where(c => c.OrderStatus == "1").ToListAsync();
            if (orders.Count == 0)
            {
                throw new Exception("error");
            }
            return orders;
        }
        public async Task<Order> GetOrderIDAsync(int id)
        {
            var orders = await _dbContext.Orders.Where(c => c.OrderStatus == "1" && c.OrderID == id).FirstOrDefaultAsync();
            if (orders == null)
            {
                throw new Exception("error");
            }
            return orders;
        }
        public async Task<List<Order>> GetOrderHistoryAsync(int id)
        {
            var orders = await _dbContext.Orders.Where(c => c.UserID == id && c.OrderStatus == "1").ToListAsync();
            if (orders.Count == 0)
            {
                orders = new List<Order>();
            }
            return orders;
        }
        public async Task GetOrderConfirmAsync(int id)
        {
            var orders = await _dbContext.Orders.Where(c => c.OrderID == id && c.OrderStatus == "1").FirstOrDefaultAsync();
            if (orders == null)
            {
                throw new Exception("error");
            }
            orders.OrderNote = "Confirmed";
            _dbContext.Orders.Update(orders);
            await _dbContext.SaveChangesAsync();
        }
    }
}