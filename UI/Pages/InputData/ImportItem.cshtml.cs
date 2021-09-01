using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class ImportItemModel : PageModel
    {
        private readonly ILogger<ImportItemModel> _logger;

        public ImportItemModel(ILogger<ImportItemModel> logger)
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
            bool isDocumentIdCorrect = (Repository.ImportDocId > 0);

            _logger.LogInformation($"OnPostAddBtn (product_title: {product_title}, quantity: {quantity}, item_price: {item_price}) for ImportDocId = {Repository.ImportDocId})"); 

            if (isProductCorrect && isQuantityCorrect && isPriceCorrect && 
                isDocumentIdCorrect)
            {
                Repository.Instance.InsertImportItem(product_title, quantity, 
                    item_price, Repository.ImportDocId); 
                _logger.LogInformation($"Added ImportItem (product_title: {product_title}, quantity: {quantity}, item_price: {item_price}) for ImportDocId = {Repository.ImportDocId})"); 
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
                Repository.Instance.UpdateImportItem(item_id, product_title, 
                    quantity, item_price); 
                _logger.LogInformation($"Edit ImportItem (product_title: {product_title}, quantity: {quantity}, item_price: {item_price})"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostDeleteBtn(int item_id)
        {
            Repository.Instance.DeleteImportItem(item_id);
            return RedirectToPage(); 
        }
    }
}
