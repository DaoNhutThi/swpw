using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CustomCart
    {
         public int CartId { get; set; }

        public string ProductName { get; set; }

        public int CartQuantity { get; set; }

        public string ProductImage { get; set; }

        public double Price { get; set; }
    }
}