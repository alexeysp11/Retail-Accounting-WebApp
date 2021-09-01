using System;
using System.Collections.Generic;
using System.Linq;
using Retail.Accounting.Models; 

namespace Retail.Accounting.Services
{
    public static class ImportService
    {
        public static void InsertImportDoc(string docNum, int employeeId, 
            int supplierId, DateTime dateTime)
        {
            using (var db = new AccountingContext())
            {
                db.Add(new ImportDoc 
                { 
                    DocNum = docNum, 
                    EmployeeId = employeeId, 
                    SupplierId = supplierId, 
                    DateTime = dateTime 
                });
                db.SaveChanges();
            }
        }

        public static void InsertImportItem(string productTitle, float quantity, 
            float price, int importDocId)
        {
            try
            {
                ProductService.InsertProductIfNotExists(productTitle); 
                using (var db = new AccountingContext())
                {
                    var product = db.Product.Where(p => p.Title == productTitle).ToList(); 
                    db.Add(new ImportItem 
                    { 
                        Quantity = quantity, 
                        Price = price, 
                        ProductId = product[0].ProductId, 
                        ImportDocId = importDocId 
                    });
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static dynamic GetImportDocs()
        {
            IEnumerable<ImportDocInfo> importDocs; 
            using (var db = new AccountingContext())
            {
                importDocs = (from id in db.Set<ImportDoc>()
                    from c in db.Set<Client>().Where(c => id.SupplierId == c.ClientId) 
                    from e in db.Set<Employee>().Where(e => id.EmployeeId == e.EmployeeId) 
                    select new ImportDocInfo
                    {
                        ImportDocId = id.ImportDocId, 
                        DocNum = id.DocNum, 
                        EmployeeName = e.EmployeeName,
                        SupplierName = c.ClientName, 
                        DateTime = id.DateTime
                    }).ToList(); 
            }
            return importDocs; 
        }

        public static dynamic GetImportItems(int importDocId)
        {
            object importItems; 
            using (var db = new AccountingContext())
            {
                importItems = (from ii in db.Set<ImportItem>()
                    from p in db.Set<Product>().Where(p => ii.ProductId == p.ProductId)
                    where ii.ImportDocId == importDocId
                    select new ImportItemInfo 
                    { 
                        ImportItemId = ii.ImportItemId, 
                        ProductName = p.Title, 
                        Quantity = ii.Quantity,
                        Price = ii.Price, 
                        TotalPrice = ii.Quantity * ii.Price
                    }).ToList(); 
            }
            return importItems; 
        }
    }
}