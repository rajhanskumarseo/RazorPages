using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebAppRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string receiver1 { get; set; }

        public void OnGet()
        {
            if (User.Identity.Name == "amit@yopmail.com")
            {
                receiver1 = "c025fe20-b1eb-45d9-9e28-f88d70f53a80";
            }

            if (User.Identity.Name == "rajhansk@yopmail.com")
            {
                receiver1 = "06b12b03-86be-4240-beb6-87be5519aadc";
            }
        }
    }
}
