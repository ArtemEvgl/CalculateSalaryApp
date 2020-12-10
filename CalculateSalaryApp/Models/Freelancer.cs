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
        public Freelancer(string name, int salaryForHour, string position) : base(name, position)
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

        public override bool Equals(object obj)
        {
            return obj is Freelancer freelancer &&
                   salaryForHour == freelancer.salaryForHour &&
                   SalaryForHour == freelancer.SalaryForHour;
        }

        public override int GetHashCode()
        {
            int hashCode = 1824010248;
            hashCode = hashCode * -1521134295 + salaryForHour.GetHashCode();
            hashCode = hashCode * -1521134295 + SalaryForHour.GetHashCode();
            return hashCode;
        }

        public override string GetTotalReport(DateTime startDate, DateTime finishDate)
        {
            var reportDays = Tasks.Where(task => task.DateTime <= finishDate && task.DateTime >= startDate);
            int hours = reportDays.Sum(task => task.Hour);
            int sum = hours * salaryForHour;
            string report = String.Format("{0} worked {1} hours and earned {2}", Name, hours, sum);
            return report;
        }
    }
}
