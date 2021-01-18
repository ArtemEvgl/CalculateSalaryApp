using System;
using CalculateSalaryApp.Api;
using CalculateSalaryApp.Application;
using CalculateSalaryApp.Model;
using DataAccess;


namespace CalculateSalaryApp.CMD
{
    class Program
    {
        private static EmployeeRepository employeeRepository;

        /// <summary>
        /// Перед первым запуском программы, необходимо запустить проект GenerateDataScript для генерации тестовых данных
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            AuthController authController = StartUp();

            Console.WriteLine("Welcome, please enter your name:");

            while (true)
            {
                string lastName = Console.ReadLine();
                Employee user = authController.Login(lastName);
                if (user is Director director)
                {
                    StartWorkWithDirector(director);

                }
                else if (user is Proger proger)
                {
                    StartWorkWithProger(proger);
                }
                else if (user is Freelancer freelancer)
                {
                    StartWithFreelancer(freelancer);
                }
                else
                {
                    Console.WriteLine("Error! Please enter your name again");
                    continue;
                }
                break;
            }

        }

        private static AuthController StartUp()
        {
            CsvSettings csvSettings = new CsvSettings(';', "..\\..\\..\\DataCSV\\");
            employeeRepository = new EmployeeRepository(csvSettings);
            AuthService authService = new AuthService(employeeRepository);
            AuthController authController = new AuthController(authService);
            return authController;
        }

        private static void StartWithFreelancer(Freelancer freelancer)
        {
            PrintHello(freelancer);
            Console.ReadKey();
        }

        private static void StartWorkWithProger(Proger proger)
        {
            PrintHello(proger);
            Console.ReadKey();
        }

        private static void StartWorkWithDirector(Director director)
        {
            PrintHello(director);
            Console.Write(new string('*', 20));
            Console.Write("Menu");
            Console.WriteLine(new string('*', 20));
            while (true)
            {
                ShowDirectorMenu(out Settings.DirectorMenuItem menuItem);
                switch (menuItem)
                {

                    case Settings.DirectorMenuItem.AddEmployee:
                        ShowDirectorAddEmployeeMenu(out Settings.DirectorAddEmployeeMenuItem menuAddEmployeeItem);
                        AddEmployee(menuAddEmployeeItem);
                        break;
                    case Settings.DirectorMenuItem.AddTimeLog:
                        break;
                    case Settings.DirectorMenuItem.GetTotalReport:
                        break;
                    case Settings.DirectorMenuItem.GetConcreteReport:
                        break;
                    case Settings.DirectorMenuItem.Exit:
                    default:
                        return;
                }
            }
           
        }

        private static void AddEmployee(Settings.DirectorAddEmployeeMenuItem menuAddEmployeeItem)
        {
            EmployeeService employeeService = new EmployeeService(employeeRepository);
            if (menuAddEmployeeItem != Settings.DirectorAddEmployeeMenuItem.Back)
            {
                GetLastNameAndSalary(out string lastName, out decimal salary);
                switch (menuAddEmployeeItem)
                {
                    case Settings.DirectorAddEmployeeMenuItem.AddDirector:
                        DirectorController directorController = new DirectorController(employeeService);                        
                        GetBonus(out decimal bonus);
                        directorController.AddDirector(new Director(lastName, salary, bonus));
                        break;
                    case Settings.DirectorAddEmployeeMenuItem.AddProger:
                        StaffController staffController = new StaffController(employeeService);
                        staffController.AddStaffEmployee(new Proger(lastName, salary));
                        break;
                    case Settings.DirectorAddEmployeeMenuItem.AddFreelancer:
                        FreelancerController freelancerController = new FreelancerController(employeeService);
                        freelancerController.AddFreelancer(new Freelancer(lastName, salary));
                        break;
                    default:
                        break;
                }
            }
            
        }

        private static void GetLastNameAndSalary (out string lastName, out decimal salary)
        {
            Console.WriteLine("Enter last name:");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter salary:");
            bool isValidInputSalary = decimal.TryParse(Console.ReadLine(), out salary);
            while (!isValidInputSalary)
            {
                Console.WriteLine("Value of salary is invalid, please try again");
                isValidInputSalary = decimal.TryParse(Console.ReadLine(), out salary);
            }
        }

        private static void GetBonus(out decimal bonus)
        {
            Console.WriteLine("Enter bonus:");
            bool isValidInputBonus = decimal.TryParse(Console.ReadLine(), out bonus);
            while (!isValidInputBonus)
            {
                Console.WriteLine("Value of salary is invalid, please try again");
                isValidInputBonus = decimal.TryParse(Console.ReadLine(), out bonus);
            }
        }
        private static void ShowDirectorAddEmployeeMenu(out Settings.DirectorAddEmployeeMenuItem menuItem)
        {
            menuItem = Settings.DirectorAddEmployeeMenuItem.Back;
            bool isValidInputData = false;
            while (!isValidInputData)
            {
                Console.WriteLine("1) Add director;");
                Console.WriteLine("2) Add proger;");
                Console.WriteLine("3) Add freelancer;");
                Console.WriteLine("4) Back");
                isValidInputData = int.TryParse(Console.ReadLine(), out int inputItem) &&
                                     Enum.IsDefined(typeof(Settings.DirectorAddEmployeeMenuItem), inputItem);
                if (isValidInputData)
                {
                    menuItem = (Settings.DirectorAddEmployeeMenuItem)inputItem;
                }
                else
                {
                    Console.WriteLine("Menu item is invalid please try again");
                }
            }
        }

        private static void ShowDirectorMenu(out Settings.DirectorMenuItem menuItem)
        {
            menuItem = Settings.DirectorMenuItem.Exit;
            bool isValidInputData = false;
            while (!isValidInputData)
            {
                Console.WriteLine("1) Add employee;");
                Console.WriteLine("2) Add time log;");
                Console.WriteLine("3) Get total report;");
                Console.WriteLine("4) Get report for concrete employee;");
                Console.WriteLine("5) Exit");
                isValidInputData = int.TryParse(Console.ReadLine(), out int inputItem) &&
                                     Enum.IsDefined(typeof(Settings.DirectorMenuItem), inputItem);
                if (isValidInputData)
                {
                    menuItem = (Settings.DirectorMenuItem)inputItem;
                } else
                {
                    Console.WriteLine("Menu item is invalid please try again");
                }
            }
        }

        public static void PrintHello(Employee employee)
        {
            Console.WriteLine($"Welcome {employee.LastName}");
        }
    }
}
