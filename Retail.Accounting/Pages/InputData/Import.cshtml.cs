using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class ImportModel : PageModel
    {
        private readonly ILogger<ImportModel> _logger;

        public ImportModel(ILogger<ImportModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
