using CalculateSalaryApp.Model;
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
            List<Employee> allEmployees = new List<Employee>();
            allEmployees.AddRange(repository.Load<Director>(Settings.directorsFile));
            allEmployees.AddRange(repository.Load<Proger>(Settings.progersFile));
            allEmployees.AddRange(repository.Load<Freelancer>(Settings.freelancerFile));
            return allEmployees.SingleOrDefault(u => u.Name == name);

        }

        //public bool AddEmployee(Employee employee)
        //{
        //    bool result = true;
        //    if (employee is Director director)
        //    {
        //        directors.Add(director);
        //        Save<Director>(directors, Settings.directorsFile);
        //    }
        //    else if (employee is Proger proger)
        //    {
        //        progers.Add(proger);
        //        Save<Proger>(progers, Settings.progersFile);
        //    }
        //    else if (employee is Freelancer freelancer)
        //    {
        //        freelancers.Add(freelancer);
        //        Save<Freelancer>(freelancers, Settings.freelancerFile);
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //    return result;

        //}

        public void AddEmployee<T> (T employee, string fileName) where T : class
        {
            List<T> employees = repository.Load<T>(fileName);
            employees.Add(employee);
            repository.Save<T>(employees, fileName);
        }

    }
}
