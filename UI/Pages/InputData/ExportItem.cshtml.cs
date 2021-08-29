using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class ExportItemModel : PageModel
    {
        private readonly ILogger<ExportItemModel> _logger;

        public ExportItemModel(ILogger<ExportItemModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
