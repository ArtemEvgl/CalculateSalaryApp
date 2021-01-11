using CalculateSalaryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Domain
{
    public interface IEmployeeRepository
    {

        void Add(Employee employee);
        Employee GetEmployee(string lastname);
    }
}
