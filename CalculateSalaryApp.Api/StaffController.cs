using CalculateSalaryApp.Domain;
using CalculateSalaryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Api
{
    public class StaffController
    {
        private readonly IEmployeeService _employeeService;
        public StaffController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public bool AddStaffEmployee(Proger proger)
        {
            return _employeeService.AddEmployee(proger);
        }
    }
}
