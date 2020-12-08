
using CalculateSalaryApp.CMD;
using CalculateSalaryApp.Controllers;
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
            AuthorizationController authorizationController = new AuthorizationController(name);
        }
    }
}
