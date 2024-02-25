using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;
using DataAccess.DAO;
using Repository.IService;

namespace Repository.Service
{
    public class AccountService : IAccountService
    {
        private readonly AccountDAO _accountDAO;

        public AccountService(AccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public Task<bool> LoginAsync(string Email, string Password)
        {
            return Task.Run(() => _accountDAO.CheckLogin(Email, Password));
        }

        public Task RegisterAsync(RegisterDTO account)
        {
            return _accountDAO.Add(account);
        }

        public Task<Account> GetAccByIdAsync(int id)
        {
            return _accountDAO.GetByID(id);
        }
        public Task<StorgeUser> GetAccByEmailAsync(string email)
        {
            return _accountDAO.GetByEmail(email);
        }
        public Task<List<AccountView>>LoadAsync()
        {
            return _accountDAO.GetAllAccounts();
        }
        public Task<AccountView> GetProfile(int id){
            return _accountDAO.GetProfile(id);
        }
        public Task ChangePerAsync(int id)
        {
            return _accountDAO.Update(id);
        }

        public Task BanAsync(int id)
        {
            return _accountDAO.Delete(id);
        }
        public Task VerifiedAsync(int id)
        {
            return _accountDAO.Verified(id);
        }
        public Task<string> ForgotAsync(string email)
        {
            return _accountDAO.ForgotPassword(email);
        }
        public int CountAcc()
        {
            return _accountDAO.CountAcc();
        }
         public int CountPro()
        {
            return _accountDAO.CountPro();
        }
         public int CountOrder()
        {
            return _accountDAO.CountOrder();
        }
         public double money()
        {
            return _accountDAO.money();
        }
        public double moneywithmonth(int month)
        {
            return _accountDAO.moneywithmonth(month);
        }

        public Task UpdateAccount(AccountView acc, int id){
            return _accountDAO.UpdateAccount(acc, id);
        }

        public Task ChangePass(ChangePassView acc, int id){
            return _accountDAO.ChangePass(acc, id);
        }
    }
}
