using CalculateSalaryApp.CMD;
using CalculateSalaryApp.DataWorker;
using CalculateSalaryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Controllers
{
    
    class DirectorController
    {
        private Director director;
        private DirectoRepository directorRepository;


        public DirectorController(Director director, DirectoRepository directorRepository)
        {
            this.director = director;
            this.directorRepository = directorRepository;
            ShowDirectorMenu();
        }


        
        private void ShowDirectorMenu()
        {
            bool success;
            int itemMenu;
            do
            {
                View.SendMessage("Select and enter item of menu");
                View.ShowMenuDirector(director.Name);
                success = Int32.TryParse(Console.ReadLine(), out itemMenu);
            } while (!success && itemMenu > 0 && itemMenu < 7);
            StartMenuOperation((DirectorMenuOperation)itemMenu);
        }

        //Todo: забрать из контроллера даты, подумать о том что надо возвращаьб в отчете не строчку а число и потом формировать уже отчет ибо даты известны а надо еще считать общую сумму
        private void StartMenuOperation(DirectorMenuOperation directorMenuOperation)
        {
            switch (directorMenuOperation)
            {

                case DirectorMenuOperation.AddUser:
                    ShowSelectEmployeeSubMenu();
                    break;
                case DirectorMenuOperation.ShowReportForAll:
                case DirectorMenuOperation.ShowReportForSpecific:
                case DirectorMenuOperation.AddHours:
                case DirectorMenuOperation.DeleteEmployee:
                    DeleteEmployee();
                    break;
                case DirectorMenuOperation.Exit:
                default:
                    return;
            }
        }

        private void ShowSelectEmployeeSubMenu()
        {
            bool success;
            int itemMenu;
            do
            {
                View.SendMessage("Select and enter item of menu");
                View.ShowSelectEmployeeSubMenu();
                success = Int32.TryParse(Console.ReadLine(), out itemMenu);
            } while (!success && itemMenu > 0 && itemMenu < 5);
            if (itemMenu == 4)
            {
                ShowDirectorMenu();
            }
            else
            {
                StartSubMenuSelectEmployeeOper((AddOperation)itemMenu);
            }

        }
        
        private void StartSubMenuSelectEmployeeOper(AddOperation addOperation)
        {
            
            
            var workData = GetWorkData(addOperation);
            switch(addOperation)
            {
                case AddOperation.AddDirector:
                    Director addDirector = new Director(workData.name, workData.monthSalary, workData.bonus, workData.position);
                    directorRepository.AddEmployee<Director>(addDirector, Settings.directorsFile);
                    ShowDirectorMenu();
                    break;
                case AddOperation.AddProger:
                    Proger addProger = new Proger(workData.name, workData.monthSalary, workData.position);
                    directorRepository.AddEmployee<Proger>(addProger, Settings.progersFile);
                    ShowDirectorMenu();
                    break;
                case AddOperation.AddFreelancer:
                    Freelancer addFreelancer = new Freelancer(workData.name, workData.monthSalary, workData.position);
                    directorRepository.AddEmployee<Freelancer>(addFreelancer, Settings.freelancerFile);
                    ShowDirectorMenu();
                    break;
                default:
                    ShowDirectorMenu();
                    break;
            }
        }

        //Todo: доделать проверку
        private (string name, string position, int monthSalary, int bonus) GetWorkData(AddOperation addOperation)
        {
            View.SendMessage("Name: ");
            string name = Console.ReadLine();
            View.SendMessage("position: ");
            string position = Console.ReadLine();
            int salary;
            int bonus = 0;
            if (addOperation != AddOperation.AddFreelancer)
            {
                View.SendMessage("Month Salary: ");
                Int32.TryParse(Console.ReadLine(), out salary);
                bonus = addOperation == AddOperation.AddDirector ? GetBonus() : 0;
            } else
            {
                View.SendMessage("Salary for hour: ");
                Int32.TryParse(Console.ReadLine(), out salary);
            }
            return (name: name, position : position, monthSalary : salary, bonus : bonus);
        }

        private int GetBonus()
        {
            bool result = false;
            int bonus = 0;
            do
            {
                View.SendMessage("bonus: ");
                result = Int32.TryParse(Console.ReadLine(), out bonus);
            } while (!result);
            return bonus;
        }

        private void DeleteEmployee()
        {
            View.SendMessage("Enter name: ");
            string name = Console.ReadLine();
            if (directorRepository.DeleteEmployee(name))
            {
                View.SendMessage("Employee deleted");
            } else
            {
                View.SendMessage("Deleted is failed");
            }
            ShowDirectorMenu();
        }
    }
}
