using System;

namespace Retail.Accounting.Services
{
    public class ImportItemInfo
    {
        public int ImportItemId { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public float Price { get; set; }
        public int ImportDocId { get; set; }
    }
}
