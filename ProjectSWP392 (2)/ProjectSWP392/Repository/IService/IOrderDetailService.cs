using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;
using DataAccess.DAO;

namespace Repository.IService
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetailAdminResponse>> GetOrderDetailHistoryAsync(int id);

    }
}