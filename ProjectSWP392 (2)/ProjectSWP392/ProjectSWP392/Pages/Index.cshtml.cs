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

namespace ProjectSWP392.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _dbcontext;

        public IndexModel(ILogger<IndexModel> logger , IProductService dBContext)
        {
            _logger = logger;
            _dbcontext = dBContext;
        }
      
        public List<Product> product {get;set;}
        public async Task OnGet()
        {
            product = await _dbcontext.GetProduct();
        }
    }
}
