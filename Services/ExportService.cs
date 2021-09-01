using System;
using System.Collections.Generic;
using System.Linq;
using Retail.Accounting.Models; 

namespace Retail.Accounting.Services
{
    public static class ExportService
    {
        public static void InsertExportDoc(string docNum, int employeeId, 
            int purchaserId, DateTime dateTime)
        {
            using (var db = new AccountingContext())
            {
                db.Add(new ExportDoc 
                { 
                    DocNum = docNum, 
                    EmployeeId = employeeId, 
                    PurchaserId = purchaserId, 
                    DateTime = dateTime 
                });
                db.SaveChanges();
            }
        }

        public static void InsertExportItem(string productTitle, float quantity, 
            float price, int exportDocId)
        {
            try
            {
                ProductService.InsertProductIfNotExists(productTitle); 
                using (var db = new AccountingContext())
                {
                    var product = db.Product.Where(p => p.Title == productTitle).ToList(); 
                    db.Add(new ExportItem 
                    { 
                        Quantity = quantity, 
                        Price = price, 
                        ProductId = product[0].ProductId, 
                        ExportDocId = exportDocId 
                    });
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static dynamic GetExportDocs()
        {
            IEnumerable<ExportDocInfo> exportDocs; 
            using (var db = new AccountingContext())
            {
                exportDocs = (from ed in db.Set<ExportDoc>()
                    from c in db.Set<Client>().Where(c => ed.PurchaserId == c.ClientId) 
                    from e in db.Set<Employee>().Where(e => ed.EmployeeId == e.EmployeeId) 
                    select new ExportDocInfo
                    {
                        ExportDocId = ed.ExportDocId, 
                        DocNum = ed.DocNum, 
                        EmployeeName = e.EmployeeName,
                        PurchaserName = c.ClientName, 
                        DateTime = ed.DateTime
                    }).ToList(); 
            }
            return exportDocs; 
        }

        public static dynamic GetExportItems(int exportDocId)
        {
            object exportItems; 
            using (var db = new AccountingContext())
            {
                exportItems = (from ei in db.Set<ExportItem>()
                    from p in db.Set<Product>().Where(p => ei.ProductId == p.ProductId)
                    where ei.ExportDocId == exportDocId
                    select new ExportItemInfo
                    { 
                        ExportItemId = ei.ExportItemId, 
                        ProductName = p.Title, 
                        Quantity = ei.Quantity,
                        Price = ei.Price, 
                        TotalPrice = ei.Quantity * ei.Price
                    }).ToList(); 
            }
            return exportItems; 
        }

        public static void UpdateExportDoc(int exportDocId, string docNum, 
            int employeeId, int purchaserId, DateTime dateTime)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var exportDocs = db.ExportDocs
                        .Where(id => id.ExportDocId == exportDocId)
                        .ToList(); 
                    exportDocs[0].DocNum = docNum; 
                    exportDocs[0].EmployeeId = employeeId; 
                    exportDocs[0].PurchaserId = purchaserId; 
                    exportDocs[0].DateTime = dateTime; 
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void UpdateExportItem(int exportItemId, int productId, 
            float quantity, float price)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var exportItems = db.ExportItems
                        .Where(ei => ei.ExportItemId == exportItemId)
                        .ToList(); 
                    
                    exportItems[0].ProductId = productId; 
                    exportItems[0].Quantity = quantity; 
                    exportItems[0].Price = price; 
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void DeleteExportDoc(int exportDocId)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var exportDoc = db.ExportDocs
                        .Where(ed => ed.ExportDocId == exportDocId)
                        .ToList()
                        .First(); 
                    db.Remove(exportDoc);
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void DeleteExportItem(int exportItemId)
        {
            try
            {
                using (var db = new AccountingContext())
                {
                    var exportItem = db.ExportItems
                        .Where(ei => ei.ExportItemId == exportItemId)
                        .ToList()
                        .First(); 
                    db.Remove(exportItem);
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}