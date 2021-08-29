using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class ClientsModel : PageModel
    {
        private readonly ILogger<ClientsModel> _logger;

        public ClientsModel(ILogger<ClientsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
