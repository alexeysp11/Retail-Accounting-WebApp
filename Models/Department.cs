using System;
using System.Collections.Generic; 

namespace Retail.Accounting.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public int Title { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
