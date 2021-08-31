using System;

namespace Retail.Accounting.Services
{
    public class InventaryItemInfo
    {
        public int InventaryItemId { get; set; }
        public string ProductName { get; set; }
        public float Quantity { get; set; }
        public int InventaryDocId { get; set; }
    }
}
