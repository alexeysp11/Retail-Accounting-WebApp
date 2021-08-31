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
    }
}