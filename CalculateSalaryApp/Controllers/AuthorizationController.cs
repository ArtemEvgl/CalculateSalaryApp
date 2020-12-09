using CalculateSalaryApp.DataWorker;
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
    public class AuthorizationController
    {


        

        public AuthorizationController(string name, AuthorizationRepository authorizationRepository)
        {

            Authorization(name, authorizationRepository);
        }

        //Todo: обеспечить безотказность
        private void Authorization(string name, AuthorizationRepository authorizationRepository)
        {
            Employee searchResult = authorizationRepository.Authorization(name);         
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
            ManagerRepository managerRepository = new ManagerRepository(new JsonRepository());
            if (searchResult is Director director)
            {

                DirectoRepository directorRepository = new DirectoRepository(managerRepository);
                new DirectorController(director, directorRepository);
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
