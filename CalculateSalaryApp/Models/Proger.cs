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
        private int monthSalary;
        private int bonus;
        public Proger(string name, int monthSalary, string position) : base(name, position)
        {
            MonthSalary = monthSalary;
            Bonus = MonthSalary / Settings.WorkHoursInMonth * 2;
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

        public override bool Equals(object obj)
        {
            return obj is Proger proger &&
                   monthSalary == proger.monthSalary &&
                   bonus == proger.bonus &&
                   MonthSalary == proger.MonthSalary &&
                   Bonus == proger.Bonus;
        }

        public override int GetHashCode()
        {
            int hashCode = -374643154;
            hashCode = hashCode * -1521134295 + monthSalary.GetHashCode();
            hashCode = hashCode * -1521134295 + bonus.GetHashCode();
            hashCode = hashCode * -1521134295 + MonthSalary.GetHashCode();
            hashCode = hashCode * -1521134295 + Bonus.GetHashCode();
            return hashCode;
        }

        public override ReportData GetReport(DateTime startDate, DateTime finishDate)
        {
            int payPerHour = MonthSalary / Settings.WorkDaysInMonth / Settings.WorkHoursInDay;            
            int salary = 0;
            var reportTasks = Tasks != null ? Tasks.Where(task => task.DateTime >= startDate && task.DateTime <= finishDate) : new List<TaskWork>();
            foreach (var task in reportTasks)
            {
                if (task.Hour <= Settings.WorkHoursInDay)
                {
                    salary += payPerHour * task.Hour;
                } 
                else
                {
                    salary += payPerHour * Settings.WorkHoursInDay;
                    salary += Bonus * (task.Hour - 8);
                }
            }
            int hours = reportTasks.Sum(task => task.Hour);
            //string report = String.Format("{0} worked {1} hours and earned {2}", Name, hours, payReport);
            return new ReportData(hours, salary);

        }
    }
}
