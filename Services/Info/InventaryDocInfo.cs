using System;
using System.Collections.Generic; 

namespace Retail.Accounting.Services
{
    public class InventaryDocInfo
    {
        public int InventaryDocId { get; set; }
        public string DocNum { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateTime { get; set; }

    }
}
