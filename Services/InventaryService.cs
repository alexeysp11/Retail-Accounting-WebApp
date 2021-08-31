using System;
using System.Collections.Generic;
using System.Linq;
using Retail.Accounting.Models; 

namespace Retail.Accounting.Services
{
    public static class InventaryService
    {
        public static void InsertInventaryDoc(string docNum, int employeeId, 
            DateTime dateTime)
        {
            using (var db = new AccountingContext())
            {
                db.Add(new InventaryDoc 
                { 
                    DocNum = docNum, 
                    EmployeeId = employeeId, 
                    DateTime = dateTime 
                });
                db.SaveChanges();
            }
        }

        public static void InsertInventaryItem(string productTitle, float quantity, 
            int inventaryDocId)
        {
            try
            {
                ProductService.InsertProductIfNotExists(productTitle); 
                using (var db = new AccountingContext())
                {
                    var product = db.Product.Where(p => p.Title == productTitle).ToList(); 
                    db.Add(new InventaryItem 
                    { 
                        Quantity = quantity, 
                        ProductId = product[0].ProductId, 
                        InventaryDocId = inventaryDocId 
                    });
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static dynamic GetInventaryDocs()
        {
            IEnumerable<InventaryDocInfo> inventaryDocs; 
            using (var db = new AccountingContext())
            {
                inventaryDocs = (from id in db.Set<InventaryDoc>()
                    from e in db.Set<Employee>().Where(e => id.EmployeeId == e.EmployeeId) 
                    select new InventaryDocInfo
                    {
                        InventaryDocId = id.InventaryDocId, 
                        DocNum = id.DocNum, 
                        EmployeeName = e.EmployeeName,
                        DateTime = id.DateTime
                    }).ToList(); 
            }
            return inventaryDocs; 
        }

        public static dynamic GetInventaryItem(int inventaryDocId)
        {
            object inventaryItems; 
            using (var db = new AccountingContext())
            {
                inventaryItems = (from ii in db.Set<InventaryItem>()
                    from p in db.Set<Product>().Where(p => ii.ProductId == p.ProductId)
                    where ii.InventaryDocId == inventaryDocId
                    select new 
                    { 
                        itemId = ii.InventaryItemId, 
                        productTitle = p.Title, 
                        quantity = ii.Quantity 
                    }).ToList(); 
            }
            return inventaryItems; 
        }
    }
}