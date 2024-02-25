using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class StorgeUser
    {
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public string FullName { get; set; }
        public bool isVerified { get; set; }
        public bool Admin { get; set; }
        public string AccountStatus {get;set;}
    }
}