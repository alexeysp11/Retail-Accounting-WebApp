# Getting data from database and displaying it 

If you need to get data from a database and display it as a table, use the following structure in the `.cshtml` files: 
```HTML
@try
{
    var exportDocs = Repository.Instance.GetExportDocs(); 
    <table id="export_table" class="stripe row-border order-column" style="width:80%">
        <thead>
            <tr>
                <th>Document ID</th>
                <th>Document number</th>
                <th>Employee</th>
                <th>Purchaser</th>
                <th>Date</th>
            </tr>
        </thead>
        <tbody>
            @{
                foreach (var doc in exportDocs)
                {
                    <tr>
                        <td>@doc.ExportDocId</td>
                        <td>@doc.DocNum</td>
                        <td>@doc.EmployeeName</td>
                        <td>@doc.PurchaserName</td>
                        <td>@doc.DateTime.Date.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-US"))</td>
                    </tr>
                }
            }
        </tbody>
        <tfoot>
            <tr>
                <th>Document ID</th>
                <th>Document number</th>
                <th>Employee</th>
                <th>Purchaser</th>
                <th>Date</th>
            </tr>
        </tfoot>
    </table>
}
catch (System.Exception)
{
    <p>Unable to draw the table.</p>
}
```

As you can see, `Repository` class initializes an instance of `AccountingRepository` class:
```C#
namespace Retail.Accounting
{
    public static class Repository
    {
        private static IAccountingRepository accountingRepository = null; 
        public static IAccountingRepository Instance
        {
            get
            {
                if (accountingRepository == null)
                {
                    accountingRepository = new AccountingRepository(); 
                }
                return accountingRepository; 
            }
        }
        ...
    }
}
```

So, then you need to declare the method signature in the `IAccountingRepository` interface (it is located in the `Services` directory):
```C#
namespace Retail.Accounting.Services
{
    public interface IAccountingRepository
    {
        ...
        IEnumerable<ImportDocInfo> GetImportDocs(); 
        ...
    }
}
```

In the method `AccountingRepository.GetExportDocs()` call the service for getting data about export (in our case, it is `ExportService` class):
```C#
namespace Retail.Accounting.Services
{
    public class AccountingRepository : IAccountingRepository
    {
        ...
        public IEnumerable<ExportDocInfo> GetExportDocs()
        {
            return ExportService.GetExportDocs(); 
        }
        ...
    }
}
```

The `ExportService` class is used for low-level interaction with the database.
```C#
namespace Retail.Accounting.Services
{
    public static class ExportService
    {
        ...
        public static IEnumerable<ExportDocInfo> GetExportDocs()
        {
            IEnumerable<ExportDocInfo> exportDocs; 
            using (var db = new AccountingContext())
            {
                exportDocs = (from ed in db.Set<ExportDoc>()
                    from c in db.Set<Partner>().Where(c => ed.PurchaserId == c.PartnerId) 
                    from e in db.Set<Employee>().Where(e => ed.EmployeeId == e.EmployeeId) 
                    select new ExportDocInfo
                    {
                        ExportDocId = ed.ExportDocId, 
                        DocNum = ed.DocNum, 
                        EmployeeName = e.EmployeeName,
                        PurchaserName = c.PartnerName, 
                        DateTime = ed.DateTime
                    }).ToList(); 
            }
            return exportDocs; 
        }
        ...
    }
}
```

