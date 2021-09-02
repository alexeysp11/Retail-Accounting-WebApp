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

        public IActionResult OnPostAddBtn(string document_number, string employee, 
            DateTime date_time)
        {
            bool isNumberCorrect = (document_number != null && document_number != string.Empty);
            bool isEmployeeCorrect = (employee != null && employee != string.Empty);

            if (isNumberCorrect && isEmployeeCorrect)
            {
                Repository.Instance.InsertInventaryDoc(document_number, employee, 
                    date_time); 
                Repository.IsErrorMessageActivatedOnInventary = false; 
                _logger.LogInformation($"Added new InventaryDoc (document_number: {document_number}, employee: {employee}, date_time: {date_time})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnInventary = true; 
                Repository.ErrorMessageOnInventary = Repository.GetErrorMessage("Add", 
                    "document number or employee name"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(int document_id, string document_number, 
            string employee, DateTime date_time)
        {
            bool isNumberCorrect = (document_number != null && document_number != string.Empty);
            bool isEmployeeCorrect = (employee != null && employee != string.Empty);

            if (isNumberCorrect && isEmployeeCorrect)
            {
                Repository.Instance.UpdateInventaryDoc(document_id, document_number, 
                    employee, date_time); 
                Repository.IsErrorMessageActivatedOnInventary = false; 
                _logger.LogInformation($"Edited InventaryDoc (document_number: {document_number}, employee: {employee}, date_time: {date_time})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnInventary = true; 
                Repository.ErrorMessageOnInventary = Repository.GetErrorMessage("Edit", 
                    "document ID, document number or employee name"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostDeleteBtn(int document_id)
        {
            bool isDocIdCorrect = (document_id > 0); 
            if (isDocIdCorrect)
            {
                Repository.Instance.DeleteInventaryDoc(document_id);
                Repository.IsErrorMessageActivatedOnInventary = false; 
                _logger.LogInformation($"Deleted InventaryDoc with ID: {document_id}"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnInventary = true; 
                Repository.ErrorMessageOnInventary = Repository.GetErrorMessage("Delete", "document ID"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostWatchBtn(int document_id)
        {
            bool isDocIdCorrect = (document_id > 0); 
            if (isDocIdCorrect)
            {
                Repository.InventaryDocId = document_id; 
                Repository.IsErrorMessageActivatedOnInventary = false; 
                _logger.LogInformation($"Request for InventaryDoc with ID: {document_id}"); 
                return RedirectToPage("InventaryItem");
            }
            else
            {
                Repository.IsErrorMessageActivatedOnInventary = true; 
                Repository.ErrorMessageOnInventary = Repository.GetErrorMessage("Watch", "document ID"); 
            }
            return RedirectToPage(); 
        }

        public void OnPostCloseErrorBtn()
        {
            Repository.IsErrorMessageActivatedOnInventary = false; 
        }
    }
}
