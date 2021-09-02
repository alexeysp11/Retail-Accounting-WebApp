using System; 
using System.Collections.Generic; 
using System.Linq;
using Retail.Accounting.Models; 

namespace Retail.Accounting.Services
{
    public class AccountingRepository : IAccountingRepository
    {
        #region ImportDoc
        public void InsertImportDoc(string docNum, string employeeName, 
            string supplierName, DateTime dateTime)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName); 
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null); 
                employeeId = EmployeeService.GetEmployeeId(employeeName); 
            }

            int? supplierId = ClientService.GetClientId(supplierName); 
            if (supplierId == null)
            {
                ClientService.InsertClient(supplierName, string.Empty, string.Empty); 
                supplierId = ClientService.GetClientId(supplierName); 
            }

            ImportService.InsertImportDoc(docNum, (int)employeeId, (int)supplierId, dateTime); 
        }

        public IEnumerable<ImportDocInfo> GetImportDocs()
        {
            return ImportService.GetImportDocs(); 
        }

        public void UpdateImportDoc(int importDocId, string docNum, 
            string employeeName, string supplierName, DateTime dateTime)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName); 
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null); 
                employeeId = EmployeeService.GetEmployeeId(employeeName); 
            }

            int? supplierId = ClientService.GetClientId(supplierName); 
            if (supplierId == null)
            {
                ClientService.InsertClient(supplierName, string.Empty, string.Empty); 
                supplierId = ClientService.GetClientId(supplierName); 
            }

            ImportService.UpdateImportDoc( importDocId, docNum, (int)employeeId, 
                (int)supplierId, dateTime ); 
        }

        public void DeleteImportDoc(int importDocId)
        {
            ImportService.DeleteImportDoc(importDocId); 
        }
        #endregion  // ImportDoc

        #region ImportItem
        public void InsertImportItem(string productTitle, float quantity, 
            float price, int importDocId)
        {
            ImportService.InsertImportItem(productTitle, quantity, price, 
                importDocId); 
        }

        public IEnumerable<ImportItemInfo> GetImportItems(int importDocId)
        {
            return ImportService.GetImportItems(importDocId); 
        }

        public void UpdateImportItem(int importItemId, string productTitle, 
            float quantity, float price)
        {
            try
            {
                ProductService.InsertProductIfNotExists(productTitle); 
                var product = ProductService.GetProducts()
                    .Where(p => p.Title == productTitle)
                    .First();
                ImportService.UpdateImportItem(importItemId, product.ProductId, 
                    quantity, price); 
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void DeleteImportItem(int importItemId)
        {
            ImportService.DeleteImportItem(importItemId); 
        }
        #endregion  // ImportItem

        #region ExportDoc
        public void InsertExportDoc(string docNum, string employeeName, 
            string purchaserName, DateTime dateTime)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName); 
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null); 
                employeeId = EmployeeService.GetEmployeeId(employeeName); 
            }

            int? purchaserId = ClientService.GetClientId(purchaserName); 
            if (purchaserId == null)
            {
                ClientService.InsertClient(purchaserName, string.Empty, string.Empty); 
                purchaserId = ClientService.GetClientId(purchaserName); 
            }

            ExportService.InsertExportDoc(docNum, (int)employeeId, (int)purchaserId, dateTime); 
        }

        public IEnumerable<ExportDocInfo> GetExportDocs()
        {
            return ExportService.GetExportDocs(); 
        }

        public void UpdateExportDoc(int exportDocId, string docNum, 
            string employeeName, string purchaserName, DateTime dateTime)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName); 
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null); 
                employeeId = EmployeeService.GetEmployeeId(employeeName); 
            }

            int? purchaserId = ClientService.GetClientId(purchaserName); 
            if (purchaserId == null)
            {
                ClientService.InsertClient(purchaserName, string.Empty, string.Empty); 
                purchaserId = ClientService.GetClientId(purchaserName); 
            }

            ExportService.UpdateExportDoc( exportDocId, docNum, (int)employeeId, 
                (int)purchaserId, dateTime ); 
        }

        public void DeleteExportDoc(int exportDocId)
        {
            ExportService.DeleteExportDoc(exportDocId); 
        }
        #endregion  // ExportDoc

        #region ExportItem
        public void InsertExportItem(string productTitle, float quantity, 
            float price, int exportDocId)
        {
            ExportService.InsertExportItem(productTitle, quantity, price, 
                exportDocId);
        }

        public IEnumerable<ExportItemInfo> GetExportItems(int exportDocId)
        {
            return ExportService.GetExportItems(exportDocId);
        }

        public void UpdateExportItem(int exportItemId, string productTitle, 
            float quantity, float price)
        {
            try
            {
                ProductService.InsertProductIfNotExists(productTitle); 
                var product = ProductService.GetProducts()
                    .Where(p => p.Title == productTitle)
                    .First();
                ExportService.UpdateExportItem(exportItemId, product.ProductId, 
                    quantity, price); 
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void DeleteExportItem(int exportItemId)
        {
            ExportService.DeleteExportItem(exportItemId);
        }
        #endregion  // ExportItem

        #region InventaryDoc 
        public void InsertInventaryDoc(string docNum, string employeeName, 
            DateTime dateTime)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName); 
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null); 
                employeeId = EmployeeService.GetEmployeeId(employeeName); 
            }
            InventaryService.InsertInventaryDoc(docNum, (int)employeeId, dateTime); 
        }

        public IEnumerable<InventaryDocInfo> GetInventaryDocs()
        {
            return InventaryService.GetInventaryDocs(); 
        }

        public void UpdateInventaryDoc(int inventaryDocId, string docNum, 
            string employeeName, DateTime dateTime)
        {
            int? employeeId = EmployeeService.GetEmployeeId(employeeName); 
            if (employeeId == null)
            {
                EmployeeService.InsertEmployee(employeeName, 0, string.Empty, 
                    string.Empty, null, null); 
                employeeId = EmployeeService.GetEmployeeId(employeeName); 
            }

            InventaryService.UpdateInventaryDoc(inventaryDocId, docNum, 
                (int)employeeId, dateTime); 
        }

        public void DeleteInventaryDoc(int inventaryDocId)
        {
            InventaryService.DeleteInventaryDoc(inventaryDocId); 
        }
        #endregion  // InventaryDoc 

        #region InventaryItem
        public void InsertInventaryItem(string productTitle, float quantity, 
            int inventaryDocId)
        {
            InventaryService.InsertInventaryItem(productTitle, quantity, 
                inventaryDocId); 
        }

        public IEnumerable<InventaryItemInfo> GetInventaryItems(int inventaryDocId)
        {
            return InventaryService.GetInventaryItems(inventaryDocId);
        }

        public void UpdateInventaryItem(int inventaryItemId, string productTitle, 
            float quantity)
        {
            try
            {
                ProductService.InsertProductIfNotExists(productTitle); 
                var product = ProductService.GetProducts()
                    .Where(p => p.Title == productTitle)
                    .First();
                InventaryService.UpdateInventaryItem(inventaryItemId, 
                    product.ProductId, quantity); 
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void DeleteInventaryItem(int inventaryItemId)
        {
            InventaryService.DeleteInventaryItem(inventaryItemId); 
        }
        #endregion  // InventaryItem

        #region Employees
        public void InsertEmployee(string employeeName, float salary, 
            string email, string phone, string managerName, 
            string departmentTitle)
        {
            int? managerId = EmployeeService.GetEmployeeId(managerName); 
            if (managerId == null)
            {
                EmployeeService.InsertEmployee(managerName, 0, string.Empty, 
                    string.Empty, null, null); 
                managerId = EmployeeService.GetEmployeeId(managerName); 
            }

            DepartmentService.InsertDepartmentIfNotExists(departmentTitle); 
            int? departmentId = DepartmentService.GetDepartmentId(departmentTitle); 

            EmployeeService.InsertEmployee(employeeName, salary, email, phone, 
                managerId, departmentId); 
        }

        public IEnumerable<EmployeeInfo> GetEmployees()
        {
            return EmployeeService.GetEmployees(); 
        }

        public void UpdateEmployee(int employeeId, string employeeName, 
            float salary, string email, string phone, string managerName, 
            string departmentTitle)
        {
            int? managerId = EmployeeService.GetEmployeeId(managerName); 
            if (managerId == null)
            {
                EmployeeService.InsertEmployee(managerName, 0, string.Empty, 
                    string.Empty, null, null); 
                managerId = EmployeeService.GetEmployeeId(managerName); 
            }

            DepartmentService.InsertDepartmentIfNotExists(departmentTitle); 
            int? departmentId = DepartmentService.GetDepartmentId(departmentTitle); 

            EmployeeService.UpdateEmployee(employeeId, employeeName, salary, 
                email, phone, managerId, departmentId); 
        }

        public void DeleteEmployee(int employeeId)
        {
            EmployeeService.DeleteEmployee(employeeId); 
        }
        #endregion  // Employees

        #region Clients
        public void InsertClient(string clientName, string company, string email, 
            string phone)
        {
            ClientService.InsertClient(clientName, email, phone); 
        }

        public List<Client> GetClients()
        {
            return ClientService.GetClients(); 
        }

        public void UpdateClient(int clientId, string clientName, 
            string email, string phone)
        {
            ClientService.UpdateClient(clientId, clientName, email, phone);
        }

        public void DeleteClient(int clientId)
        {
            ClientService.DeleteClient(clientId); 
        }
        #endregion  // Clients
    }
}