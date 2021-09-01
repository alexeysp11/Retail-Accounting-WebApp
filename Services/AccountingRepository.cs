using System; 
using System.Collections.Generic; 
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

        public dynamic GetImportDocs()
        {
            return ImportService.GetImportDocs(); 
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
        #endregion  // ImportDoc

        #region ImportItem
        public void InsertImportItem(string productTitle, float quantity, 
            float price, int importDocId)
        {
            ImportService.InsertImportItem(productTitle, quantity, price, 
                importDocId); 
        }

        public dynamic GetImportItems(int importDocId)
        {
            return ImportService.GetImportItems(importDocId); 
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

        public dynamic GetExportDocs()
        {
            return ExportService.GetExportDocs(); 
        }
        #endregion  // ExportDoc

        #region ExportItem
        public void InsertExportItem(string productTitle, float quantity, 
            float price, int exportDocId)
        {
            ExportService.InsertExportItem(productTitle, quantity, price, 
                exportDocId);
        }

        public dynamic GetExportItems(int exportDocId)
        {
            return ExportService.GetExportItems(exportDocId);
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

        public dynamic GetInventaryDocs()
        {
            return InventaryService.GetInventaryDocs(); 
        }
        #endregion  // InventaryDoc 

        #region InventaryItem
        public void InsertInventaryItem(string productTitle, float quantity, 
            int inventaryDocId)
        {
            InventaryService.InsertInventaryItem(productTitle, quantity, 
                inventaryDocId); 
        }

        public dynamic GetInventaryItems(int inventaryDocId)
        {
            return InventaryService.GetInventaryItems(inventaryDocId);
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

        public List<Employee> GetEmployees()
        {
            return EmployeeService.GetEmployees(); 
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
        #endregion  // Clients
    }
}