using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;

namespace Repository.IService
{
    public interface ICartService
    {
        Task AddToCartAsync(int proid , int userId);
        Task<List<CustomCart>> GetCartsAsync(int id);
        Task DeleteAsync(int id);
        Task PlusAsync(int id);
        Task SubAsync(int id);

    }
}