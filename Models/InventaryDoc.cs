using System;

namespace Retail.Accounting.Models
{
    public class InventaryDoc
    {
        public int InventaryDocId { get; set; }
        public string DocNum { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
