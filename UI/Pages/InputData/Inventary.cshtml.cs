using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class InventaryModel : PageModel
    {
        private readonly ILogger<InventaryModel> _logger;

        public InventaryModel(ILogger<InventaryModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
