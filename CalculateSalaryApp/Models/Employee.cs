using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Model
{
    public class Employee
    {
        public Employee(string name, List<TaskWork> tasks, string position)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым");
            }
            Name = name;
            Tasks = tasks;
            Position = position;

        }

        //TODO: Проверка
        public string Name { get; }
        public List<TaskWork> Tasks { get; }

        public string Position { get; }




    }
}
