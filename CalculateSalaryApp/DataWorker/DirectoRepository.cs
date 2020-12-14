using CalculateSalaryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.DataWorker
{
    public class DirectoRepository
    {
        ManagerRepository managerRepository;
        public DirectoRepository(ManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }

        public void AddEmployee<T>(T employee, string fileName) where T : class
        {
            managerRepository.AddEmployee<T>(employee, fileName);
        }

        public bool DeleteEmployee(string fileName)
        {
            return managerRepository.DeleteEmployee(fileName);
        }

        public string GetTotalReport(DateTime start, DateTime finish)
        {
            return managerRepository.GetTotalReport(start, finish);
        }

        public Employee GetEmployee(string name)
        {
            return managerRepository.SearchEmployee(name);
        }

        public string GetSpicificReport(DateTime start, DateTime finish, Employee emp)
        {
            return managerRepository.GetSpecificReport(start, finish, emp);
        }
    }
}
