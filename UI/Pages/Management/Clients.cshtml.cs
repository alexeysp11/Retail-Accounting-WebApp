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
                Repository.IsErrorMessageActivatedOnClients = false; 
                _logger.LogInformation($"Added new Client (client_name: {client_name}, company: {company})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnClients = true; 
                Repository.ErrorMessageOnClients = Repository.GetErrorMessage("Add", 
                    "client name, company, email or phone"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(int client_id, string client_name, 
            string company, string email, string phone)
        {
            bool isClientIdCorrect = (client_id > 0); 
            bool isClientNameCorrect = (client_name != null && client_name != string.Empty);
            bool isCompanyCorrect = (company != null && company != string.Empty);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isClientIdCorrect && isClientNameCorrect && isCompanyCorrect && 
                isEmailCorrect && isPhoneCorrect)
            {
                Repository.Instance.UpdateClient(client_id, client_name, email, 
                    phone); 
                Repository.IsErrorMessageActivatedOnClients = false; 
                _logger.LogInformation($"Edited a Client (client_name: {client_name}, company: {company})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnClients = true; 
                Repository.ErrorMessageOnClients = Repository.GetErrorMessage("Edit", 
                    "client ID, client name, company, email or phone"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostDeleteBtn(int client_id)
        {
            bool isClientIdCorrect = (client_id > 0); 
            if (isClientIdCorrect)
            {
                Repository.Instance.DeleteClient(client_id);
                Repository.IsErrorMessageActivatedOnClients = false; 
                _logger.LogInformation($"Deleted client with ID: {client_id}"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnClients = true; 
                Repository.ErrorMessageOnClients = Repository.GetErrorMessage("Delete", "client ID"); 
            }
            return RedirectToPage(); 
        }

        public void OnPostCloseErrorBtn()
        {
            Repository.IsErrorMessageActivatedOnClients = false; 
        }
    }
}
