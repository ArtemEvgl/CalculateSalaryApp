using CalculateSalaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Model
{
    public class Director : Employee
    {
        private decimal bonus;

        public Director(string name, decimal salary, decimal bonus) : base(name, salary)
        {
            Bonus = bonus;
        }

        

        public decimal Bonus {
            get
            {
                return bonus;
            }
            set
            {
                if (value > 0)
                {
                    bonus = value;
                }
                else
                {
                    throw new ArgumentException("Зарплата не может быть равно или меньше нуля");
                }
            }
        }


        public override string GetPersonalData(char delimeter)
        {
            return $"{LastName}{delimeter}{Salary}{delimeter}Руководитель{delimeter}{Bonus}{delimeter}\n";
        }



    }
    

}
