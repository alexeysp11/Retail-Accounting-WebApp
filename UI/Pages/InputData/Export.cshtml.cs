using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class ExportModel : PageModel
    {
        private readonly ILogger<ExportModel> _logger;

        public ExportModel(ILogger<ExportModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostAddBtn(string document_number, string employee, 
            string purchaser, DateTime date_time)
        {
            bool isNumberCorrect = (document_number != null && document_number != string.Empty);
            bool isEmployeeCorrect = (employee != null && employee != string.Empty);
            bool isPurchaserCorrect = (purchaser != null && purchaser != string.Empty);

            if (isNumberCorrect && isEmployeeCorrect && isPurchaserCorrect)
            {
                Repository.Instance.InsertExportDoc(document_number, employee, 
                    purchaser, date_time); 
                _logger.LogInformation($"Added new ExportDoc (document_number: {document_number}, employee: {employee}, purchaser: {purchaser}, date_time: {date_time})"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(int document_id, string document_number, 
            string employee, string purchaser, DateTime date_time)
        {
            bool isNumberCorrect = (document_number != null && document_number != string.Empty);
            bool isEmployeeCorrect = (employee != null && employee != string.Empty);
            bool isPurchaserCorrect = (purchaser != null && purchaser != string.Empty);

            if (isNumberCorrect && isEmployeeCorrect && isPurchaserCorrect)
            {
                Repository.Instance.UpdateExportDoc(document_id, document_number, 
                    employee, purchaser, date_time); 
                _logger.LogInformation($"Edited Export (document_number: {document_number}, employee: {employee}, purchaser: {purchaser}, date_time: {date_time})"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostDeleteBtn(int document_id)
        {
            Repository.Instance.DeleteExportDoc(document_id); 
            _logger.LogInformation($"Deleted ExportDoc with ID: {document_id}"); 
            return RedirectToPage(); 
        }

        public IActionResult OnPostWatchBtn(int document_id)
        {
            Repository.ExportDocId = document_id; 
            _logger.LogInformation($"Request for ExportDoc with ID: {document_id}"); 
            return RedirectToPage("ExportItem");
        }
    }
}
