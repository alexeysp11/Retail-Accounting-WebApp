using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class InventaryItemModel : PageModel
    {
        private readonly ILogger<InventaryItemModel> _logger;

        public InventaryItemModel(ILogger<InventaryItemModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
