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
        
        public Director(string name, List<TaskWork> tasks, int monthSalary, int bonus, string position) : base(name, tasks, position)
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

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="file"></param>
        public void AddEmp(Employee emp, string file)
        {

        }

        /// <summary>
        /// Добавление времени сотруднику
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="file"></param>
        /// <param name="hours"></param>
        public void AddTimeWork(Employee emp, Task task)
        {

        }

        /// <summary>
        /// Получение отчета по всем сотрудникам за введенный период
        /// </summary>
        /// <param name="workPeriod"></param>
        /// <returns></returns>
        public string GetReport(WorkPeriod workPeriod)
        {
            return "";
        }
        
        /// <summary>
        /// Получение отчета за конкретного сотрудника
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="workPeriod"></param>
        /// <returns></returns>
        public string GetReportEmp(Employee emp,  WorkPeriod workPeriod)
        {
            return "";
        }

    }
    public enum WorkPeriod
    {
        Day, Week, Month
    }

}
