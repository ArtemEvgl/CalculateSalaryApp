using CalculateSalaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Model
{
    public class Proger : Employee
    {
        public Proger(string name, decimal salary) : base(name, salary)
        {
        }

        public override string GetPersonalData(char delimeter)
        {
            return $"{LastName}{delimeter}{Salary}{delimeter}Штатный сотрудник{delimeter}\n";
        }
    }
}
