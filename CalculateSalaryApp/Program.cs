
using CalculateSalaryApp.CMD;
using CalculateSalaryApp.Controllers;
using CalculateSalaryApp.DataWorker;
using CalculateSalaryApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp
{
    class Program
    {
        static void Main(string[] args)
        {

            View.SendMessage("Hello, please enter your name: ");
            string name = Console.ReadLine();
            ManagerRepository managerRepository = new ManagerRepository(new JsonRepository());
            AuthorizationRepository authorizationRepository = new AuthorizationRepository(managerRepository);
            AuthorizationController authorizationController = new AuthorizationController(name, authorizationRepository);
        }
    }
}
