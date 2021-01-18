using CalculateSalaryApp.Domain;
using CalculateSalaryApp.Model;
using System;

namespace CalculateSalaryApp.Application
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public bool AddEmployee(Employee employee)
        {
            bool isValid = !string.IsNullOrEmpty(employee.LastName) && employee.Salary > 0;
            if (isValid)
            {
                _employeeRepository.Add(employee);
            }
            return isValid;
        }
    }
}
