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
                _logger.LogInformation($"Added new InventaryDoc (document_number: {document_number}, employee: {employee}, date_time: {date_time})"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(string document_number, string employee, 
            DateTime date_time)
        {
            bool isNumberCorrect = (document_number != null && document_number != string.Empty);
            bool isEmployeeCorrect = (employee != null && employee != string.Empty);

            if (isNumberCorrect && isEmployeeCorrect)
            {
                _logger.LogInformation($"Inventary, EditBtn\ndocument_number: {document_number}, employee: {employee}, date_time: {date_time}"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostWatchBtn(int document_id)
        {
            Repository.InventaryDocId = document_id; 
            _logger.LogInformation($"Request for InventaryDoc with ID: {document_id}"); 
            return RedirectToPage("InventaryItem");
        }
    }
}
