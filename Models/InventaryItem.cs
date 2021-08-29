using System;

namespace Retail.Accounting.Models
{
    public class InventaryItem
    {
        public int InventaryItemId { get; set; }
        public int ProductId { get; set; }
        public float Quantity { get; set; }

        public int InventaryDocId { get; set; }
        public InventaryDoc InventaryDoc { get; set; }
    }
}
