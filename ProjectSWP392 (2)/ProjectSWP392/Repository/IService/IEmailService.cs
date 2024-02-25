using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessObject.Models;
using BusinessObject.DTO;

namespace Repository.IService
{
    public interface IEmailService
    {
        Task SendMail(MailContent mailContent);
        Task SendEmailAsync(string email, string subject, string message);
    }
}