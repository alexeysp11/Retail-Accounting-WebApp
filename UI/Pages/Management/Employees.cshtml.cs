using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Retail.Accounting.Pages
{
    public class EmployeesModel : PageModel
    {
        private readonly ILogger<EmployeesModel> _logger;

        public EmployeesModel(ILogger<EmployeesModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostAddBtn(string employee_name, string manager_name, 
            string department, float salary, string email, string phone)
        {
            bool isEmployeeCorrect = (employee_name != null && employee_name != string.Empty);
            bool isManagerCorrect = (manager_name != null && manager_name != string.Empty);
            bool isDepartmentCorrect = (department != null && department != string.Empty);
            bool isSalaryCorrect = (salary > 0);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isEmployeeCorrect && isManagerCorrect && isDepartmentCorrect && 
                isSalaryCorrect && isEmailCorrect && isPhoneCorrect)
            {
                Repository.Instance.InsertEmployee(employee_name, salary, email, 
                    phone, manager_name, department); 
                _logger.LogInformation($"Added new Employee (employee_name: {employee_name}, manager_name: {manager_name}, department: {department})"); 
            }
            return RedirectToPage(); 
        }

        public IActionResult OnPostEditBtn(string employee_name, string manager_name, 
            string department, float salary, string email, string phone)
        {
            bool isEmployeeCorrect = (employee_name != null && employee_name != string.Empty);
            bool isManagerCorrect = (manager_name != null && manager_name != string.Empty);
            bool isDepartmentCorrect = (department != null && department != string.Empty);
            bool isSalaryCorrect = (salary > 0);
            bool isEmailCorrect = (email != null && email != string.Empty);
            bool isPhoneCorrect = (phone != null && phone != string.Empty);

            if (isEmployeeCorrect && isManagerCorrect && isDepartmentCorrect && 
                isSalaryCorrect && isEmailCorrect && isPhoneCorrect)
            {
                _logger.LogInformation($"Edited an Employee (employee_name: {employee_name}, manager_name: {manager_name}, department: {department})"); 
            }
            return RedirectToPage(); 
        }
    }
}
