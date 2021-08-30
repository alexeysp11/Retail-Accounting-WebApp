using System;
using System.Collections.Generic;
using System.Linq;
using Retail.Accounting.Models; 

namespace Retail.Accounting.Services
{
    public static class AccountingService
    {
        #region Insert 
        public static void InsertClient(string clientName, string email, string phone)
        {
            using (var db = new AccountingContext())
            {
                db.Add(new Client { ClientName = clientName, Email = email, Phone = phone });
                db.SaveChanges();
            }
        }

        public static void InsertEmployee(string employeeName, float salary, string email, 
            string phone, int? managerId, int? departmentId)
        {
            using (var db = new AccountingContext())
            {
                var employeeList = db.Employee
                    .Where(p => p.EmployeeName == employeeName)
                    .ToList(); 
                
                if (employeeList.Count == 0)
                {
                    db.Add(new Employee 
                    { 
                        EmployeeName = employeeName, 
                        Salary = salary, 
                        Email = email, 
                        Phone = phone, 
                        ManagerId = managerId, 
                        DepartmentId = departmentId
                    });
                    db.SaveChanges();
                }
            }
        }

        public static void InsertEmployeeFromUi(string employeeName, float salary, string email, 
            string phone, string managerName, string departmentTitle)
        {
            int? managerId = AccountingService.GetEmployeeId(managerName); 
            if (managerId == null)
            {
                AccountingService.InsertEmployee(managerName, 0, $"{managerName}@example.com", 
                    string.Empty, null, null); 
                managerId = AccountingService.GetEmployeeId(managerName); 
            }

            AccountingService.InsertDepartmentIfNotExists(departmentTitle); 
            int? departmentId = AccountingService.GetDepartmentId(departmentTitle); 

            AccountingService.InsertEmployee(employeeName, salary, email, phone, 
                managerId, departmentId); 
        }

        public static void InsertContract(int employeeId, DateTime dateTimeStart, 
            DateTime? dateTimeEnd)
        {
            using (var db = new AccountingContext())
            {
                db.Add(new Contract 
                { 
                    EmployeeId = employeeId, 
                    EmploymentDate = dateTimeStart, 
                    TerminationDate = dateTimeEnd 
                }); 
                db.SaveChanges();
            }
        }

        public static void InsertContractFromUi(string employeeName, DateTime dateTimeStart, 
            DateTime? dateTimeEnd)
        {
            int? employeeId = AccountingService.GetEmployeeId(employeeName); 
            if (employeeId == null)
            {
                AccountingService.InsertEmployee(employeeName, 0, $"{employeeName}@example.com", 
                    string.Empty, null, null); 
                employeeId = AccountingService.GetEmployeeId(employeeName); 
            }
            AccountingService.InsertContract((int)employeeId, dateTimeStart, dateTimeEnd); 
        }

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

        public static void InsertImportDoc(string docNum, int employeeId, int supplierId, 
            DateTime dateTime)
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

        public static void InsertImportDocFromUi(string docNum, string employeeName, 
            string supplierName, DateTime dateTime)
        {
            int? employeeId = AccountingService.GetEmployeeId(employeeName); 
            if (employeeId == null)
            {
                AccountingService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null); 
                employeeId = AccountingService.GetEmployeeId(employeeName); 
            }

            int? supplierId = AccountingService.GetClientId(supplierName); 
            if (supplierId == null)
            {
                AccountingService.InsertClient(supplierName, string.Empty, string.Empty); 
                supplierId = AccountingService.GetClientId(supplierName); 
            }

            AccountingService.InsertImportDoc(docNum, (int)employeeId, (int)supplierId, dateTime); 
        }

        public static void InsertImportItem(string productTitle, float quantity, float price, 
            int importDocId)
        {
            try
            {
                AccountingService.InsertProductIfNotExists(productTitle); 
                using (var db = new AccountingContext())
                {
                    var product = db.Product.Where(p => p.Title == productTitle).ToList(); 
                    db.Add(new ImportItem { Quantity = quantity, Price = price, ProductId = product[0].ProductId, ImportDocId = importDocId });
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void InsertExportDoc(string docNum, int employeeId, int purchaserId, 
            DateTime dateTime)
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

        public static void InsertExportDocFromUi(string docNum, string employeeName, 
            string purchaserName, DateTime dateTime)
        {
            int? employeeId = AccountingService.GetEmployeeId(employeeName); 
            if (employeeId == null)
            {
                AccountingService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null); 
                employeeId = AccountingService.GetEmployeeId(employeeName); 
            }

            int? purchaserId = AccountingService.GetClientId(purchaserName); 
            if (purchaserId == null)
            {
                AccountingService.InsertClient(purchaserName, string.Empty, string.Empty); 
                purchaserId = AccountingService.GetClientId(purchaserName); 
            }

            AccountingService.InsertExportDoc(docNum, (int)employeeId, (int)purchaserId, dateTime); 
        }

        public static void InsertExportItem(string productTitle, float quantity, float price, 
            int exportDocId)
        {
            try
            {
                AccountingService.InsertProductIfNotExists(productTitle); 
                using (var db = new AccountingContext())
                {
                    var product = db.Product.Where(p => p.Title == productTitle).ToList(); 
                    db.Add(new ExportItem { Quantity = quantity, Price = price, ProductId = product[0].ProductId, ExportDocId = exportDocId });
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void InsertInventaryDoc(string docNum, int employeeId, DateTime dateTime)
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

        public static void InsertInventaryDocFromUi(string docNum, string employeeName, 
            DateTime dateTime)
        {
            int? employeeId = AccountingService.GetEmployeeId(employeeName); 
            if (employeeId == null)
            {
                AccountingService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null); 
                employeeId = AccountingService.GetEmployeeId(employeeName); 
            }

            AccountingService.InsertInventaryDoc(docNum, (int)employeeId, dateTime); 
        }

        public static void InsertInventaryItem(string productTitle, float quantity, 
            int inventaryDocId)
        {
            try
            {
                AccountingService.InsertProductIfNotExists(productTitle); 
                using (var db = new AccountingContext())
                {
                    var product = db.Product.Where(p => p.Title == productTitle).ToList(); 
                    db.Add(new InventaryItem { Quantity = quantity, ProductId = product[0].ProductId, InventaryDocId = inventaryDocId });
                    db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static void InsertDepartmentIfNotExists(string departmentTitle)
        {
            using (var db = new AccountingContext())
            {
                var departmentList = db.Department
                    .Where(p => p.Title == departmentTitle)
                    .ToList(); 
                
                if (departmentList.Count == 0)
                {
                    db.Add(new Department { Title = departmentTitle });
                    db.SaveChanges();
                }
            }
        }
        #endregion  // Insert 

        #region Get 
        public static int? GetEmployeeId(string employeeName)
        {
            int? employeeId = 0; 
            using (var db = new AccountingContext())
            {
                var employeeList = db.Employee
                    .Where(e => e.EmployeeName == employeeName)
                    .ToList(); 
                
                if (employeeList.Count != 0)
                {
                    employeeId = employeeList[0].EmployeeId; 
                }
                else
                {
                    employeeId = null; 
                }
            }
            return employeeId; 
        }

        public static int? GetDepartmentId(string departmentTitle)
        {
            int? departmentId = 0; 
            using (var db = new AccountingContext())
            {
                var departmentList = db.Department
                    .Where(d => d.Title == departmentTitle)
                    .ToList(); 
                
                if (departmentList.Count != 0)
                {
                    departmentId = departmentList[0].DepartmentId; 
                }
                else
                {
                    departmentId = null; 
                }
            }
            return departmentId; 
        }

        public static int? GetClientId(string clientName)
        {
            int? clientId = 0; 
            using (var db = new AccountingContext())
            {
                var clientList = db.Client
                    .Where(c => c.ClientName == clientName)
                    .ToList(); 
                
                if (clientList.Count != 0)
                {
                    clientId = clientList[0].ClientId; 
                }
                else
                {
                    clientId = null; 
                }
            }
            return clientId; 
        }

        public static List<ImportDoc> GetImportDoc()
        {
            List<ImportDoc> importDocs = new List<ImportDoc>(); 
            using (var db = new AccountingContext())
            {
                importDocs = db.ImportDocs.OrderBy(id => id.ImportDocId).ToList(); 
            }
            return importDocs; 
        }

        public static dynamic GetImportItem(int importDocId)
        {
            object importItems; 
            using (var db = new AccountingContext())
            {
                importItems = (from ii in db.Set<ImportItem>()
                    from p in db.Set<Product>().Where(p => ii.ProductId == p.ProductId)
                    where ii.ImportDocId == importDocId
                    select new 
                    { 
                        itemId = ii.ImportItemId, 
                        productTitle = p.Title, 
                        quantity = ii.Quantity,
                        price = ii.Price
                    }).ToList(); 
            }
            return importItems; 
        }

        public static List<ExportDoc> GetExportDoc()
        {
            List<ExportDoc> exportDocs = new List<ExportDoc>(); 
            using (var db = new AccountingContext())
            {
                exportDocs = db.ExportDocs.OrderBy(ed => ed.ExportDocId).ToList(); 
            }
            return exportDocs; 
        }

        public static dynamic GetExportItem(int exportDocId)
        {
            object exportItems; 
            using (var db = new AccountingContext())
            {
                exportItems = (from ei in db.Set<ExportItem>()
                    from p in db.Set<Product>().Where(p => ei.ProductId == p.ProductId)
                    where ei.ExportDocId == exportDocId
                    select new 
                    { 
                        itemId = ei.ExportItemId, 
                        productTitle = p.Title, 
                        quantity = ei.Quantity,
                        price = ei.Price
                    }).ToList(); 
            }
            return exportItems; 
        }

        public static List<InventaryDoc> GetInventaryDoc()
        {
            List<InventaryDoc> inventaryDocs = new List<InventaryDoc>(); 
            using (var db = new AccountingContext())
            {
                inventaryDocs = db.InventaryDocs.OrderBy(ed => ed.InventaryDocId).ToList(); 
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
        #endregion // Get 
    }
}