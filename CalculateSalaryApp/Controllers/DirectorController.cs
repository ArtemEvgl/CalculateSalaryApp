using CalculateSalaryApp.CMD;
using CalculateSalaryApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Controllers
{
    class DirectorController : BaseController
    {
        private Director director;
        private List<Director> directors = new List<Director>();
        private List<Proger> progers = new List<Proger>();
        private List<Freelancer> freelancers = new List<Freelancer>();
        public DirectorController(Director director)
        {
            this.director = director;
            LoadAllEmployess();
            ShowDirectorMenu();
        }

        
        public bool AddEmployee(Employee employee)
        {
            bool result = true;
            if (employee is Director director)
            {
                directors.Add(director);
                Save<Director>(directors,Settings.directorsFile);
            }
            else if (employee is Proger proger)
            {
                progers.Add(proger);
                Save<Proger>(progers, Settings.progersFile);
            }
            else if (employee is Freelancer freelancer)
            {
                freelancers.Add(freelancer);
                Save<Freelancer>(freelancers, Settings.freelancerFile);
            } else
            {
                result = false;
            }
            return result;
            
        }

        private void LoadAllEmployess()
        {
            directors = Load<Director>(Settings.directorsFile);
            progers = Load<Proger>(Settings.progersFile);
            freelancers = Load<Freelancer>(Settings.freelancerFile);
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
            } while (!success && itemMenu > 0 && itemMenu < 6);
            StartMenuOperation(itemMenu);
        }

        private void StartMenuOperation(int itemMenu)
        {
            switch (itemMenu)
            {
                
                case 5:                    
                default:
                    break;
            }
        }
    }
}
