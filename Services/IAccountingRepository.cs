using System; 
using System.Collections.Generic;
using Retail.Accounting.Models; 

namespace Retail.Accounting.Services
{
    public interface IAccountingRepository
    {
        void InsertImportDoc(string docNum, string employeeName, 
            string supplierName, DateTime dateTime); 
        IEnumerable<ImportDocInfo> GetImportDocs(); 
        void UpdateImportDoc(int importDocId, string docNum, 
            string employeeName, string supplierName, DateTime dateTime); 
        void DeleteImportDoc(int importDocId); 

        void InsertExportDoc(string docNum, string employeeName, 
            string purchaserName, DateTime dateTime); 
        IEnumerable<ExportDocInfo> GetExportDocs(); 
        void UpdateExportDoc(int exportDocId, string docNum, 
            string employeeName, string purchaserName, DateTime dateTime); 
        void DeleteExportDoc(int exportDocId); 

        void InsertInventaryDoc(string docNum, string employeeName, 
            DateTime dateTime); 
        IEnumerable<InventaryDocInfo> GetInventaryDocs(); 
        void UpdateInventaryDoc(int inventaryDocId, string docNum, 
            string employeeName, DateTime dateTime); 
        void DeleteInventaryDoc(int inventaryDocId); 

        void InsertEmployee(string employeeName, float salary, 
            string email, string phone, string managerName, 
            string departmentTitle); 
        IEnumerable<EmployeeInfo> GetEmployees(); 
        void UpdateEmployee(int employeeId, string employeeName, 
            float salary, string email, string phone, string managerName, 
            string departmentTitle); 
        void DeleteEmployee(int employeeId); 

        void InsertClient(string clientName, string company, string email, 
            string phone); 
        List<Client> GetClients(); 
        void UpdateClient(int clientId, string clientName, string email, 
            string phone); 
        void DeleteClient(int clientId); 

        void InsertImportItem(string productTitle, float quantity, 
            float price, int importDocId); 
        IEnumerable<ImportItemInfo> GetImportItems(int importDocId); 
        void UpdateImportItem(int importItemId, string productTitle, 
            float quantity, float price); 
        void DeleteImportItem(int importItemId); 
        
        void InsertExportItem(string productTitle, float quantity, 
            float price, int exportDocId); 
        IEnumerable<ExportItemInfo> GetExportItems(int exportDocId);
        void UpdateExportItem(int exportItemId, string productTitle, 
            float quantity, float price); 
        void DeleteExportItem(int exportItemId); 
        
        void InsertInventaryItem(string productTitle, float quantity, 
            int inventaryDocId); 
        IEnumerable<InventaryItemInfo> GetInventaryItems(int inventaryDocId);
        void UpdateInventaryItem(int inventaryItemId, string productTitle, 
            float quantity); 
        void DeleteInventaryItem(int inventaryItemId); 
    }
}