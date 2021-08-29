using System;

namespace Retail.Accounting.Models
{
    public class ImportItem
    {
        public int ImportItemId { get; set; }
        public int ProductId { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public int ImportDocId { get; set; }
    }
}
