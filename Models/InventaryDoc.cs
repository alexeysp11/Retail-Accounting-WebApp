using System;
using System.Collections.Generic; 

namespace Retail.Accounting.Models
{
    public class InventaryDoc
    {
        public int InventaryDocId { get; set; }
        public string DocNum { get; set; }
        public DateTime DateTime { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public List<InventaryItem> InventaryItems { get; set; }
    }
}
