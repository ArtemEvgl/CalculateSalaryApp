using CalculateSalaryApp.Model;
using CalculateSalaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.DataWorker
{
    public class ManagerRepository
    {
        IRepository repository;
        public ManagerRepository(IRepository repository)
        {
            this.repository = repository;
        }


        public Employee SearchEmployee(string name)
        {
            List<Employee> allEmployees = GetAllEmployee();
            return allEmployees.SingleOrDefault(u => u.Name == name);

        }
        
        public bool DeleteEmployee(string fileName)
        {
            Employee employee = SearchEmployee(fileName);
            bool result = false;
            if(employee is Director director)
            {
                Delete<Director>(director, Settings.directorsFile, ref result);
            } else if(employee is Proger proger)
            {
                Delete<Proger>(proger, Settings.progersFile, ref result);
            } else if(employee is Freelancer freelancer)
            {
                Delete<Freelancer>(freelancer, Settings.freelancerFile, ref result);
            }
            return result;
        }

        

        private void Delete<T> (T employee, string fileName, ref bool result) where T : class
        {
            List<T> employees = repository.Load<T>(fileName);
            var delItems = employees.Where(emp => emp.Equals(employee));
            int a = employees.RemoveAll(e => e.Equals(employee));
            repository.Save<T>(employees, fileName);
            result = true;

        }

        public void AddEmployee<T> (T employee, string fileName) where T : class
        {
            List<T> employees = repository.Load<T>(fileName) ?? new List<T>();
            employees.Add(employee);
            repository.Save<T>(employees, fileName);
        }

        public string GetTotalReport(DateTime start, DateTime finish)
        {
            StringBuilder report = new StringBuilder($"Report per interval from {start.ToString("d")} to {finish.ToString("d")}\n\n");
            List<Employee> allEmployees = GetAllEmployee();
            int totalPay = 0, totalHour = 0;
            foreach (var emp in allEmployees)
            {
                ReportData reportData = emp.GetReport(start, finish);
                report.Append($"{emp.Name} worked {reportData.Hour} hours and earned {reportData.Pay}\n");
                totalPay += reportData.Pay;
                totalHour += reportData.Hour;
            }
            report.Append($"\nTotal hours have worked - {totalHour} total pay - {totalPay}");
            return report.ToString();
        }

        public string GetSpecificReport(DateTime start, DateTime finish, Employee emp)
        {
            StringBuilder report = new StringBuilder($"Report per interval from {start.ToString("d")} to {finish.ToString("d")}\n\n");
            ReportData reportData = emp.GetReport(start, finish);
            report.Append($"{emp.Name} worked {reportData.Hour} hours and earned {reportData.Pay}\n");
            return report.ToString();
        }

        private List<Employee> GetAllEmployee()
        {
            List<Employee> allEmployees = new List<Employee>();
            allEmployees.AddRange(repository.Load<Director>(Settings.directorsFile));
            allEmployees.AddRange(repository.Load<Proger>(Settings.progersFile) ?? new List<Proger>());
            allEmployees.AddRange(repository.Load<Freelancer>(Settings.freelancerFile) ?? new List<Freelancer>());
            return allEmployees;
        }


        public bool AddWorkingHours(Employee employee, TaskWork taskWork)
        {
            employee.Tasks.Add(taskWork);
            bool result = false;
            if (employee is Director director)
            {
                OverwriteEmployee<Director>(director, Settings.directorsFile);
                result = true;
            } else if(employee is Proger proger)
            {
                OverwriteEmployee<Proger>(proger, Settings.progersFile);
                result = true;
            } else if(employee is Freelancer freelancer)
            {
                OverwriteEmployee<Freelancer>(freelancer, Settings.freelancerFile);
                result = true;
            }
            return result;
        }

        private void OverwriteEmployee<T>(T employee, string fileName) where T : class
        {
            List<T> employees = repository.Load<T>(fileName);
            employees[employees.FindIndex(e => e.Equals(employee))] = employee;
            repository.Save<T>(employees, fileName);
        }
    }
}
