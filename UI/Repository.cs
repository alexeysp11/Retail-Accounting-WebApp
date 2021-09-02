using Retail.Accounting.Services; 

namespace Retail.Accounting
{
    public static class Repository
    {
        private static IAccountingRepository accountingRepository = null; 
        public static IAccountingRepository Instance
        {
            get
            {
                if (accountingRepository == null)
                {
                    accountingRepository = new AccountingRepository(); 
                }
                return accountingRepository; 
            }
        }

        public static int ImportDocId { get; set; }
        public static int ExportDocId { get; set; }
        public static int InventaryDocId { get; set; }

        public static bool IsErrorMessageActivatedOnImport { get; set; } = false; 
        public static bool IsErrorMessageActivatedOnImportItem { get; set; } = false; 
        public static bool IsErrorMessageActivatedOnExport { get; set; } = false; 
        public static bool IsErrorMessageActivatedOnExportItem { get; set; } = false; 
        public static bool IsErrorMessageActivatedOnInventary { get; set; } = false; 
        public static bool IsErrorMessageActivatedOnInventaryItem { get; set; } = false; 
        public static bool IsErrorMessageActivatedOnClients { get; set; } = false; 
        public static bool IsErrorMessageActivatedOnEmployees { get; set; } = false; 
        
        public static string ErrorMessageOnImport { get; set; }
        public static string ErrorMessageOnImportItem { get; set; }
        public static string ErrorMessageOnExport { get; set; }
        public static string ErrorMessageOnExportItem { get; set; }
        public static string ErrorMessageOnInventary { get; set; }
        public static string ErrorMessageOnInventaryItem { get; set; }
        public static string ErrorMessageOnClients { get; set; }
        public static string ErrorMessageOnEmployees { get; set; }

        public static string GetErrorMessage(string operationName, string possibleProblem)
        {
            return $"Unable to perform {operationName} operation. Please, check correctness of {possibleProblem}."; 
        }
    }
}