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
    public class UserDAO
    {
        private readonly DBContext _dbContext;

        public UserDAO(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetByID(int userid)
        {
            var account = await _dbContext.Users.Where(u => u.UserID == userid).SingleOrDefaultAsync();

            if (account == null)
            {
                throw new Exception("UserNotFound");
            }

            return account;
        }
        public async Task<User> GetByName(string name)
        {
            var account = await _dbContext.Users.Where(u => u.FullName == name).SingleOrDefaultAsync();

            if (account == null)
            {
                throw new Exception("UserNotFound");
            }

            return account;
        }
    }
}