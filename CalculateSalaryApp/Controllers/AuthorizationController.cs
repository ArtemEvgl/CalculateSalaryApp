using CalculateSalaryApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Controllers
{
    public class AuthorizationController : BaseController
    {

        
        private List<Employee> allEmployees = new List<Employee>();

        public AuthorizationController(string name)
        {
            allEmployees.AddRange(Load<Director>(Settings.directorsFile));
            allEmployees.AddRange(Load<Proger>(Settings.progersFile));
            allEmployees.AddRange(Load<Freelancer>(Settings.freelancerFile));
            Authorization(name);
        }

        private void Authorization(string name)
        {
            Employee searchResult = allEmployees.SingleOrDefault(u => u.Name == name);            
            if(searchResult != null)
            {
                StartUserController(searchResult);
            } else
            {
                throw new ArgumentException("Пользователя с введенным именем не найдено");
            }
        }

        private void StartUserController(Employee searchResult)
        {
            if(searchResult is Director director)
            {
                new DirectorController(director);
            } else if(searchResult is Proger proger)
            {
                new ProgerController(proger);
            } else if(searchResult is Freelancer freelancer)
            {
                new FreelancerController(freelancer);
            } else
            {
                throw new ArgumentException("Неизвестный тип пользователя");
            }
        }
    }
}
