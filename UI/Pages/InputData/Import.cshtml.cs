using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Retail.Accounting; 
using Retail.Accounting.Models; 

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

        public IActionResult OnPostAddBtn(string document_number, string employee, 
            string supplier, DateTime date_time)
        {
            bool isNumberCorrect = (document_number != null && document_number != string.Empty);
            bool isEmployeeCorrect = (employee != null && employee != string.Empty);
            bool isSupplierCorrect = (supplier != null && supplier != string.Empty);

            if (isNumberCorrect && isEmployeeCorrect && isSupplierCorrect)
            {
                Repository.Instance.InsertImportDoc(document_number, employee, 
                    supplier, date_time); 
                _logger.LogInformation($"Added Import (document_number: {document_number}, employee: {employee}, supplier: {supplier}, date_time: {date_time})"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(string document_number, string employee, 
            string supplier, DateTime date_time)
        {
            bool isNumberCorrect = (document_number != null && document_number != string.Empty);
            bool isEmployeeCorrect = (employee != null && employee != string.Empty);
            bool isSupplierCorrect = (supplier != null && supplier != string.Empty);

            if (isNumberCorrect && isEmployeeCorrect && isSupplierCorrect)
            {
                _logger.LogInformation($"Import, EditBtn\ndocument_number: {document_number}, employee: {employee}, supplier: {supplier}, date_time: {date_time}"); 
            }
            return RedirectToPage(); 
        }
    }
}
