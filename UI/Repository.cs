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
    }
}