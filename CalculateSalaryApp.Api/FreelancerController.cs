
using CalculateSalaryApp.Domain;
using CalculateSalaryApp.Model;

namespace CalculateSalaryApp.Api
{
    public class FreelancerController
    {
        private readonly IEmployeeService _employeeService;
        public FreelancerController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public bool AddFreelancer(Freelancer freelancer)
        {
            return _employeeService.AddEmployee(freelancer);
        }
    }
}
