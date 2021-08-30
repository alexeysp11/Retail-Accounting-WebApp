using System;
using System.Collections.Generic; 

namespace Retail.Accounting.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<ImportDoc> ImportDocs { get; set; }
        public List<ExportDoc> ExportDocs { get; set; }
    }
}
