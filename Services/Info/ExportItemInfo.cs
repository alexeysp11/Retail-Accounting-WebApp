using System;

namespace Retail.Accounting.Services
{
    public class ExportItemInfo
    {
        public int ExportItemId { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public int ExportDocId { get; set; }
    }
}
