using System;

namespace Retail.Accounting.Models
{
    public class ExportItem
    {
        public int ExportItemId { get; set; }
        public int ProductId { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public int ExportDocId { get; set; }
    }
}
