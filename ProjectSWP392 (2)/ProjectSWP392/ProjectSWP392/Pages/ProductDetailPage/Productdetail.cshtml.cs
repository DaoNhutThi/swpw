using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BusinessObject.Models;
using Repository.IService;
using Repository.Service;
using Microsoft.AspNetCore.Http;
using BusinessObject.DTO;
using DataAccess.Data;

namespace ProjectSWP392.Pages.ProductDetailPage
{
    public class Productdetail : PageModel
    {
        private readonly ILogger<Productdetail> _logger;
        private readonly DBContext _dBContext;
        public Product product { get; set; }

        public Productdetail(ILogger<Productdetail> logger, DBContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }

        public void OnGet(int id)
        {
            product = _dBContext.Products.Where(c => c.ProductID == id).SingleOrDefault();
        }
    }
}