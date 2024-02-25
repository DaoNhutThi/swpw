using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;
using DataAccess.DAO;
using Repository.IService;

namespace Repository.Service
{
    public class UserService : IUserService
    {
        private readonly UserDAO _userDAO;

        public UserService(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }
        public Task<User> GetUserByIdAsync(int id)
        {
            return _userDAO.GetByID(id);
        }
        public Task<User> GetUserByNameAsync(string name)
        {
            return _userDAO.GetByName(name);
        }
    }
}