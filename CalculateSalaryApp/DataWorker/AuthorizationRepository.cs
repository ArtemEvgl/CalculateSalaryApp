using CalculateSalaryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.DataWorker
{
    public class AuthorizationRepository
    {

        ManagerRepository managerRepository;
        public AuthorizationRepository(ManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }

        public Employee Authorization(string name)
        {
            return managerRepository.SearchEmployee(name);
        }
    }
}
