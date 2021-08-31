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

        public IActionResult OnPostAddBtn(string client_name, string company, 
            string email, string phone)
        {
            bool isClientCorrect = (client_name != null && client_name != string.Empty);
            bool isCompanyCorrect = (company != null && company != string.Empty);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isClientCorrect && isCompanyCorrect && isEmailCorrect && 
                isPhoneCorrect)
            {
                Repository.Instance.InsertClient(client_name, company, email, phone); 
                _logger.LogInformation($"Added new Client (client_name: {client_name}, company: {company})"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(string client_name, string company, 
            string email, string phone)
        {
            bool isClientCorrect = (client_name != null && client_name != string.Empty);
            bool isCompanyCorrect = (company != null && company != string.Empty);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isClientCorrect && isCompanyCorrect && isEmailCorrect && 
                isPhoneCorrect)
            {
                _logger.LogInformation($"Edited a Client (client_name: {client_name}, company: {company})"); 
            }
            return RedirectToPage(); 
        }
    }
}
