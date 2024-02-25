using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;

namespace Repository.IService
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string email, string password);
        Task RegisterAsync(RegisterDTO account);
        Task<Account> GetAccByIdAsync(int id);
        Task<StorgeUser> GetAccByEmailAsync(string email);
        Task<List<AccountView>> LoadAsync();
        Task<AccountView> GetProfile(int id);
        Task ChangePerAsync(int id);
        Task BanAsync(int id);
        Task VerifiedAsync(int id);
        Task<string> ForgotAsync(string email);
        int CountAcc();
        int CountPro();
        int CountOrder();
        double money();
        double moneywithmonth(int month);

        Task UpdateAccount(AccountView acc, int id);

        Task ChangePass(ChangePassView acc, int id);

    }
}