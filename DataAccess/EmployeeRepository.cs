
using CalculateSalaryApp.Domain;
using CalculateSalaryApp.Model;
using System.IO;
using System.Linq;

namespace DataAccess
{
    class EmployeeRepository : IEmployeeRepository
    {

        private char _delimiter;
        private string _path;

        public EmployeeRepository(CsvSettings csvSettings)
        {
            _path = csvSettings.Path;
            _delimiter = csvSettings.Delimiter;
        }
        public void Add(Employee employee)
        {
            string rowData = employee.GetPersonalData(_delimiter);
            File.AppendAllText(_path, rowData);
        }

        
        public Employee GetEmployee(string lastname)
        {
            string[] dataRows = File.ReadAllText(_path).Split('\n');
            Employee employee = null;
            foreach (var dataRow in dataRows)
            {
                if (dataRow.Contains(lastname))
                {
                    string[] dataMembets = dataRow.Split(_delimiter);
                    decimal salary = 0;
                    decimal.TryParse(dataMembets[1], out salary);
                    var position = dataMembets[2];
                    switch (position)
                    {
                        case "Руководитель":
                            decimal bonus = 0;
                            decimal.TryParse(dataMembets[1], out bonus);
                            employee = new Director(lastname, salary, bonus);
                            break;
                        case "Штатный сотрудник":
                            employee = new Proger(lastname, salary);
                            break;
                        case "Фрилансер":
                            employee = new Freelancer(lastname, salary);
                            break;
                        default:
                            break;
                    }
                    break;
                }
            }
            return employee;
            
        }
    }
}
