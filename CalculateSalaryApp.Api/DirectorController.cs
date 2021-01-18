

using CalculateSalaryApp.Domain;
using CalculateSalaryApp.Model;

namespace CalculateSalaryApp.Api
{
    public class DirectorController
    {
        private readonly IEmployeeService _employeeService;
        public DirectorController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public bool AddDirector(Director director)
        {
           return _employeeService.AddEmployee(director);
        }
    }
}
