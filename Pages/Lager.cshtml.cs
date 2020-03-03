using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebShop.Pages
{
    public class LagerModel : PageModel
    {
        private readonly ILogger<LagerModel> _logger;

        public LagerModel(ILogger<LagerModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
