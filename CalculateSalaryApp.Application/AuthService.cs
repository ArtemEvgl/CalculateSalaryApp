using CalculateSalaryApp.Domain;
using CalculateSalaryApp.Model;

namespace CalculateSalaryApp.Application
{
    public class AuthService : IAuthService
    {
        IEmployeeRepository _employeeRepository;
        public AuthService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Employee Login(string lastName)
        {
            Employee employee = _employeeRepository.GetEmployee(lastName);
            return employee;
        }
    }
}
