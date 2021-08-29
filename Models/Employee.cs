using System;

namespace Retail.Accounting.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public float Salary { get; set; }
        public DateTime EmploymentDate { get; set; }
        
        public int ManagerId { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
