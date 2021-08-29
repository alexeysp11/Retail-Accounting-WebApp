using System;

namespace Retail.Accounting.Models
{
    public class ImportDoc
    {
        public int ImportDocId { get; set; }
        public string DocNum { get; set; }
        public int ConsumerId { get; set; }
        public int SupplierId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
