using System; 
using System.Collections.Generic;
using Retail.Accounting.Models; 

namespace Retail.Accounting.Services
{
    public interface IAccountingRepository
    {
        void InsertImportDoc(string docNum, string employeeName, 
            string supplierName, DateTime dateTime); 
        dynamic GetImportDocs(); 
        void Update(); 
        void Delete(); 

        void InsertExportDoc(string docNum, string employeeName, 
            string purchaserName, DateTime dateTime); 
        dynamic GetExportDocs(); 

        void InsertInventaryDoc(string docNum, string employeeName, 
            DateTime dateTime); 
        dynamic GetInventaryDocs(); 

        void InsertEmployee(string employeeName, float salary, 
            string email, string phone, string managerName, 
            string departmentTitle); 
        List<Employee> GetEmployees(); 

        void InsertClient(string clientName, string company, string email, 
            string phone); 
        List<Client> GetClients(); 
    }
}