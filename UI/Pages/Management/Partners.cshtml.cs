using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class PartnersModel : PageModel
    {
        private readonly ILogger<PartnersModel> _logger;

        public PartnersModel(ILogger<PartnersModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostAddBtn(string Partner_name, string company, 
            string email, string phone)
        {
            bool isPartnerCorrect = (Partner_name != null && Partner_name != string.Empty);
            bool isCompanyCorrect = (company != null && company != string.Empty);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isPartnerCorrect && isCompanyCorrect && isEmailCorrect && 
                isPhoneCorrect)
            {
                Repository.Instance.InsertPartner(Partner_name, company, email, phone); 
                Repository.IsErrorMessageActivatedOnPartners = false; 
                _logger.LogInformation($"Added new Partner (Partner_name: {Partner_name}, company: {company})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnPartners = true; 
                Repository.ErrorMessageOnPartners = Repository.GetErrorMessage("Add", 
                    "partner name, company, email or phone"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(int Partner_id, string Partner_name, 
            string company, string email, string phone)
        {
            bool isPartnerIdCorrect = (Partner_id > 0); 
            bool isPartnerNameCorrect = (Partner_name != null && Partner_name != string.Empty);
            bool isCompanyCorrect = (company != null && company != string.Empty);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isPartnerIdCorrect && isPartnerNameCorrect && isCompanyCorrect && 
                isEmailCorrect && isPhoneCorrect)
            {
                Repository.Instance.UpdatePartner(Partner_id, Partner_name, email, 
                    phone); 
                Repository.IsErrorMessageActivatedOnPartners = false; 
                _logger.LogInformation($"Edited a Partner (Partner_name: {Partner_name}, company: {company})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnPartners = true; 
                Repository.ErrorMessageOnPartners = Repository.GetErrorMessage("Edit", 
                    "partner ID, partner name, company, email or phone"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostDeleteBtn(int Partner_id)
        {
            bool isPartnerIdCorrect = (Partner_id > 0); 
            if (isPartnerIdCorrect)
            {
                Repository.Instance.DeletePartner(Partner_id);
                Repository.IsErrorMessageActivatedOnPartners = false; 
                _logger.LogInformation($"Deleted Partner with ID: {Partner_id}"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnPartners = true; 
                Repository.ErrorMessageOnPartners = Repository.GetErrorMessage("Delete", "Partner ID"); 
            }
            return RedirectToPage(); 
        }

        public void OnPostCloseErrorBtn()
        {
            Repository.IsErrorMessageActivatedOnPartners = false; 
        }
    }
}
