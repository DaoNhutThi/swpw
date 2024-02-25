using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProjectSWP392.Pages.AdminPage
{
    public class ChangePermission : PageModel
    {
        private readonly ILogger<ChangePermission> _logger;

        public ChangePermission(ILogger<ChangePermission> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}