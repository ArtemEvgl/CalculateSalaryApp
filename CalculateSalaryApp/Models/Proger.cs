using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Model
{
    class Proger : Employee
    {
        private int monthSalary;
        private int bonus;
        public Proger(string name, List<TaskWork> tasks, int monthSalary, int bonus, string position) : base(name, tasks, position)
        {
            MonthSalary = monthSalary;
            Bonus = bonus;
        }

        public int MonthSalary
        {
            get
            {
                return monthSalary;
            }
            set
            {
                if (value > 0)
                {
                    monthSalary = value;
                }
                else
                {
                    throw new ArgumentException("Зарплата не может быть равно или меньше нуля");
                }
            }
        }

        public int Bonus
        {
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



        public void Add(Task task)
        {

        }

        public string GetReport(WorkPeriod workPeriod)
        {
            return "";
        }
    }
}
