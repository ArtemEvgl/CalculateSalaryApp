using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Model
{
    public class Freelancer : Employee
    {

        private int salaryForHour;
        public Freelancer(string name, List<TaskWork> tasks, int salaryForHour, string position) : base(name, position)
        {
            SalaryForHour = salaryForHour;
        }

        public int SalaryForHour {
            get
            {
                return salaryForHour;
            } 
            set 
            {
                if (value > 0)
                {
                    salaryForHour = value; 
                } else
                {
                    throw new ArgumentException("Зарплата не может быть равно или меньше нуля");
                }
            } 
        }
        public void Add(Task task)
        {

        }

        public string GetReport(WorkPeriod workPeriod)
        {
            return "";
        }
    }
}
