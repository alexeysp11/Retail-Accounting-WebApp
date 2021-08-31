using System;
using System.Collections.Generic;
using System.Linq;
using Retail.Accounting.Models; 

namespace Retail.Accounting.Services
{
    public static class ProductService
    {
        public static void InsertProductIfNotExists(string productTitle)
        {
            using (var db = new AccountingContext())
            {
                var productList = db.Product
                    .Where(p => p.Title == productTitle)
                    .ToList(); 
                
                if (productList.Count == 0)
                {
                    db.Add(new Product { Title = productTitle });
                    db.SaveChanges();
                }
            }
        }
    }
}