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
        private int monthSalary;
        private int bonus;
       


        public Director(string name, int monthSalary, int bonus, string position) : base(name, position)
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

        public int Bonus {
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

        

        public override bool Equals(object obj)
        {
            return obj is Director director &&
                   monthSalary == director.monthSalary &&
                   bonus == director.bonus &&
                   MonthSalary == director.MonthSalary &&
                   Bonus == director.Bonus;
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
            int payPerBonus = Bonus / Settings.WorkDaysInMonth;
            int salary = 0;
            var reportTasks = Tasks.Where(task => task.DateTime >= startDate && task.DateTime <= finishDate);
            foreach (var task in reportTasks)
            {
                if (task.Hour <= Settings.WorkHoursInDay)
                {
                    salary += task.Hour * payPerHour;
                }               
                else
                {
                    salary += task.Hour * Settings.WorkHoursInDay;
                    salary += payPerBonus;
                }
            }
            int hours = reportTasks.Sum(task => task.Hour);
            //string report = String.Format("{0} worked {1} hours and earned {2}", Name, hours, salary);            
            return new ReportData(hours, salary);
        }
    }
    

}
