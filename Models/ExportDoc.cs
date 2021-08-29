using System;

namespace Retail.Accounting.Models
{
    public class ExportDoc
    {
        public int ExportDocId { get; set; }
        public string DocNum { get; set; }
        public int SellerId { get; set; }
        public int PurchaserId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
