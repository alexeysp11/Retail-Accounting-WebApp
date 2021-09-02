using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class InventaryItemModel : PageModel
    {
        private readonly ILogger<InventaryItemModel> _logger;

        public InventaryItemModel(ILogger<InventaryItemModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostAddBtn(string product_title, float quantity)
        {
            bool isProductCorrect = (product_title != null && product_title != string.Empty);
            bool isQuantityCorrect = (quantity >= 0);
            bool isDocumentIdCorrect = (Repository.InventaryDocId > 0);

            if (isProductCorrect && isQuantityCorrect && isDocumentIdCorrect)
            {
                Repository.Instance.InsertInventaryItem(product_title, quantity, 
                    Repository.InventaryDocId); 
                Repository.IsErrorMessageActivatedOnInventaryItem = false; 
                _logger.LogInformation($"Added InventaryItem (product_title: {product_title}, quantity: {quantity}) for InventaryDocId = {Repository.InventaryDocId})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnInventaryItem = true; 
                Repository.ErrorMessageOnInventaryItem = Repository.GetErrorMessage("Add", 
                    "product title or quantity"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(int item_id, string product_title, 
            float quantity)
        {
            bool isItemIdCorrect = (item_id > 0); 
            bool isProductCorrect = (product_title != null && product_title != string.Empty);
            bool isQuantityCorrect = (quantity >= 0);

            if (isItemIdCorrect && isProductCorrect && isQuantityCorrect)
            {
                Repository.Instance.UpdateInventaryItem(item_id, product_title, 
                    quantity); 
                Repository.IsErrorMessageActivatedOnInventaryItem = false; 
                _logger.LogInformation($"Edit InventaryItem (product_title: {product_title}, quantity: {quantity})"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnInventaryItem = true; 
                Repository.ErrorMessageOnInventaryItem = Repository.GetErrorMessage("Edit", 
                    "item ID, product title or quantity"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostDeleteBtn(int item_id)
        {
            bool isItemIdCorrect = (item_id > 0); 
            if (isItemIdCorrect)
            {
                Repository.Instance.DeleteInventaryItem(item_id);
                Repository.IsErrorMessageActivatedOnInventaryItem = false; 
                _logger.LogInformation($"Deleted InventaryItem with ID: {item_id}"); 
            }
            else
            {
                Repository.IsErrorMessageActivatedOnInventaryItem = true; 
                Repository.ErrorMessageOnInventaryItem = Repository.GetErrorMessage("Delete", "item ID"); 
            }
            return RedirectToPage(); 
        }

        public void OnPostCloseErrorBtn()
        {
            Repository.IsErrorMessageActivatedOnInventaryItem = false; 
        }
    }
}
