using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class EventsModel : PageModel
    {
        private readonly ILogger<EventsModel> _logger;

        public EventsModel(ILogger<EventsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
