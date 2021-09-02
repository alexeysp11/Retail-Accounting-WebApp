using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class ExportItemModel : PageModel
    {
        private readonly ILogger<ExportItemModel> _logger;

        public ExportItemModel(ILogger<ExportItemModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostAddBtn(string product_title, float quantity, 
            float item_price)
        {
            bool isProductCorrect = (product_title != null && product_title != string.Empty);
            bool isQuantityCorrect = (quantity >= 0);
            bool isPriceCorrect = (item_price >= 0);
            bool isDocumentIdCorrect = (Repository.ExportDocId > 0);
            
            if (isProductCorrect && isQuantityCorrect && isPriceCorrect && 
                isDocumentIdCorrect)
            {
                Repository.Instance.InsertExportItem(product_title, quantity, 
                    item_price, Repository.ExportDocId); 
                _logger.LogInformation($"Added ExportItem (product_title: {product_title}, quantity: {quantity}, item_price: {item_price}) for ExportDocId = {Repository.ExportDocId})"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(int item_id, string product_title, 
            float quantity, float item_price)
        {
            bool isProductCorrect = (product_title != null && product_title != string.Empty);
            bool isQuantityCorrect = (quantity >= 0);
            bool isPriceCorrect = (item_price >= 0);

            if (isProductCorrect && isQuantityCorrect && isPriceCorrect)
            {
                Repository.Instance.UpdateExportItem(item_id, product_title, 
                    quantity, item_price); 
                _logger.LogInformation($"Edit ExportItem (product_title: {product_title}, quantity: {quantity}, item_price: {item_price})"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostDeleteBtn(int item_id)
        {
            Repository.Instance.DeleteExportItem(item_id); 
            _logger.LogInformation($"Deleted ExportItem with ID: {item_id}"); 
            return RedirectToPage(); 
        }
    }
}
