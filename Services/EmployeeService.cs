using System;
using System.Collections.Generic;
using System.Linq;
using Retail.Accounting.Models; 

namespace Retail.Accounting.Services
{
    public static class EmployeeService
    {
        public static void InsertEmployee(string employeeName, float salary, 
            string email, string phone, int? managerId, int? departmentId)
        {
            using (var db = new AccountingContext())
            {
                var employeeList = db.Employee
                    .Where(p => p.EmployeeName == employeeName)
                    .ToList(); 
                
                if (employeeList.Count == 0)
                {
                    db.Add(new Employee 
                    { 
                        EmployeeName = employeeName, 
                        Salary = salary, 
                        Email = email, 
                        Phone = phone, 
                        ManagerId = managerId, 
                        DepartmentId = departmentId
                    });
                    db.SaveChanges();
                }
            }
        }

        public static int? GetEmployeeId(string employeeName)
        {
            int? employeeId = 0; 
            using (var db = new AccountingContext())
            {
                var employeeList = db.Employee
                    .Where(e => e.EmployeeName == employeeName)
                    .ToList(); 
                
                if (employeeList.Count != 0)
                {
                    employeeId = employeeList[0].EmployeeId; 
                }
                else
                {
                    employeeId = null; 
                }
            }
            return employeeId; 
        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>(); 
            using (var db = new AccountingContext())
            {
                employees = db.Employee.OrderBy(e => e.EmployeeId).ToList(); 
            }
            return employees; 
        }
    }
}