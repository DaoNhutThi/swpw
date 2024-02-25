using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using BusinessObject.Models;
using BusinessObject.DTO;

namespace DataAccess.DAO
{
    public class AccountDAO
    {
        private readonly DBContext _dbContext;
        public Account cate { get; set; } = new Account();
        public User user { get; set; } = new User();
        public List<AccountView> av = new List<AccountView>();
        public StorgeUser cus { get; set; } = new StorgeUser();
        public double price { get; set; }

        public AccountDAO(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        int length = 10;
        private static Random random = new Random();
        public async Task<string> ForgotPassword(string email)
        {
            string sourceString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder randomString = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(sourceString.Length);
                randomString.Append(sourceString[index]);
            }
            cate = _dbContext.Accounts.SingleOrDefault(a => a.Email == email);
            if (cate == null)
            {
                throw new Exception("EmailNotFound");
            }
            cate.Password = randomString.ToString();
            _dbContext.Accounts.Update(cate);
            await _dbContext.SaveChangesAsync();
            return cate.Password;
        }

        public async Task<bool> CheckLogin(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                throw new Exception("AccountNull");
            }
            var isLoginSuccessful = await Task.Run(() =>
                _dbContext.Accounts.Any(c => c.Email == Email && c.Password == Password));

            return isLoginSuccessful;
        }

        public async Task Add(RegisterDTO account)
        {
            int countuser = _dbContext.Users.ToList().Count();
            int count = _dbContext.Accounts.ToList().Count();
            var check = await Task.Run(() =>
                _dbContext.Accounts.Where(a => a.Email == account.Email).ToList());
            if (check.Count > 0)
            {
                throw new Exception("email");
            }
            if (account.PassWord == account.ReEnterPassword)
            {
                if (countuser == 0)
                {
                    user.UserID = 1;
                }
                else
                {
                    user.UserID = countuser + 1;
                }

                user.FullName = account.FullName;
                user.Phone = account.Phone;
                user.Address = account.Address;
                user.UserStatus = "1";

                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                cate = new Account()
                {
                    UserID = user.UserID,
                    Email = account.Email,
                    Password = account.PassWord,
                    isVerified = false,
                    Admin = false,
                    AccountStatus = "1"
                };
                if (count == 0)
                {
                    cate.AccountID = 1;
                }
                else
                {
                    count++;
                    cate.AccountID = count;
                }
                _dbContext.Accounts.Add(cate);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Passnotmatch");
            }
        }

        public async Task<Account> GetByID(int accountId)
        {
            var account = await _dbContext.Accounts.Where(c => c.AccountID == accountId).FirstOrDefaultAsync();

            if (account == null)
            {
                throw new Exception("AccountNotFound");
            }

            return account;
        }
        public async Task<StorgeUser> GetByEmail(string email)
        {
            var account = await _dbContext.Accounts.Where(c => c.Email == email).SingleOrDefaultAsync();
            var user = await _dbContext.Users.Where(c => c.UserID == account.AccountID).SingleOrDefaultAsync();
            cus.AccountID = account.AccountID;
            cus.UserID = user.UserID;
            cus.FullName = user.FullName;
            cus.isVerified = account.isVerified;
            cus.Admin = account.Admin;
            cus.AccountStatus = account.AccountStatus;
            if (account == null)
            {
                throw new Exception("AccountNotFound");
            }
            return cus;
        }
        public async Task<List<AccountView>> GetAllAccounts()
        {
            var ac1 = await _dbContext.Accounts.Where(c => c.AccountStatus == "1").ToListAsync();
            foreach (var item in ac1)
            {
                user = await _dbContext.Users.Where(c => c.UserID == item.UserID).FirstOrDefaultAsync();
                AccountView acv = new AccountView();
                acv.AccountID = item.AccountID;
                acv.Email = item.Email;
                acv.FullName = user.FullName;
                acv.Address = user.Address;
                acv.Phone = user.Phone;
                acv.isVerified = item.isVerified;
                acv.Admin = item.Admin;

                av.Add(acv);
            }
            return av;
        }
        public async Task<AccountView> GetProfile(int id)
        {
            var ac1 = await _dbContext.Accounts.Where(c => c.AccountStatus == "1" && c.UserID == id).FirstOrDefaultAsync();
            user = await _dbContext.Users.Where(c => c.UserID == ac1.UserID).FirstOrDefaultAsync();
            AccountView acv = new AccountView();
            acv.AccountID = ac1.AccountID;
            acv.Email = ac1.Email;
            acv.FullName = user.FullName;
            acv.Address = user.Address;
            acv.Phone = user.Phone;
            acv.isVerified = ac1.isVerified;
            acv.Admin = ac1.Admin;
            return acv;
        }
        public async Task Update(int id)
        {
            var existingAccount = await _dbContext.Accounts.Where(c => c.AccountID == id).FirstOrDefaultAsync();

            if (existingAccount == null)
            {
                throw new Exception("AccountChangeNotFound");
            }
            if (existingAccount.Admin == false)
            {
                existingAccount.Admin = true;
                _dbContext.Accounts.Update(existingAccount);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                existingAccount.Admin = false;
                _dbContext.Accounts.Update(existingAccount);
                await _dbContext.SaveChangesAsync();
            }

        }

        public async Task UpdateAccount(AccountView acc, int id)
        {
            var existingAccount = await _dbContext.Accounts
                .Where(a => a.UserID == id)
                .FirstOrDefaultAsync();

            if (existingAccount != null)
            {
                existingAccount.Email = acc.Email;
                var user = await _dbContext.Users
                    .Where(u => u.UserID == existingAccount.UserID)
                    .FirstOrDefaultAsync();
                if (user != null)
                {

                    user.FullName = acc.FullName;
                    user.Phone = acc.Phone;
                    user.Address = acc.Address;
                }

                await _dbContext.SaveChangesAsync();
            }


        }

        public async Task ChangePass(ChangePassView acc, int id)
        {
            var existingUser = await _dbContext.Accounts
                .Where(a => a.UserID == id)
                .FirstOrDefaultAsync();

            if (existingUser != null)
            {
                
                if(existingUser.Password == acc.OldPass){
                existingUser.Password = acc.NewPass;
                _dbContext.Accounts.Update(existingUser);
                await _dbContext.SaveChangesAsync();
                }
                else{
                    throw new Exception("Loi db");
                }
            }
        }
        public async Task Verified(int accountId)
        {
            var account = await _dbContext.Accounts.Where(c => c.AccountID == accountId).FirstOrDefaultAsync();

            if (account == null)
            {
                throw new Exception("AccountBanNotFound");
            }
            account.isVerified = true;
            _dbContext.Accounts.Update(account);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int accountId)
        {
            var account = await _dbContext.Accounts.Where(c => c.AccountID == accountId).FirstOrDefaultAsync();

            if (account == null)
            {
                throw new Exception("AccountBanNotFound");
            }
            account.AccountStatus = "0";
            _dbContext.Accounts.Update(account);
            await _dbContext.SaveChangesAsync();
        }
        public int CountAcc()
        {
            var count = _dbContext.Accounts.Where(c => c.AccountStatus == "1").ToList().Count();
            return count;
        }
        public int CountPro()
        {
            var count1 = _dbContext.Products.Where(c => c.ProductStatus == "1").ToList().Count();
            return count1;
        }
        public int CountOrder()
        {
            var count2 = _dbContext.Orders.Where(c => c.OrderStatus == "1").ToList().Count();
            return count2;
        }
        public double money()
        {
            var oder = _dbContext.Orders.Where(c => c.OrderStatus == "1" && c.OrderNote == "Confirmed").ToList();
            foreach(var o in oder){
                  var ordertotal = _dbContext.OrderDetails.Where(c => c.OrderDetailStatus == "1" && c.OrderID ==o.OrderID).ToList();
                  foreach (var item in ordertotal)
                  {
                        price = price + item.OrderDetailTotalPrice;
                  }
            }
            return price;
        }
        public double moneywithmonth(int month)
        {
            double prices = 0;
            var oder = _dbContext.Orders.Where(c => c.OrderStatus == "1" && c.OrderDate.Month == month && c.OrderDate.Year == DateTime.Now.Year && c.OrderNote == "Confirmed").ToList();
            foreach (var item in oder)
            {
                var ordertotal = _dbContext.OrderDetails.Where(c => c.OrderDetailStatus == "1" && c.OrderID == item.OrderID).ToList();
                foreach (var item1 in ordertotal)
                {
                    prices = prices + item1.OrderDetailTotalPrice;
                }
            }
            return prices;
        }

    }

}

