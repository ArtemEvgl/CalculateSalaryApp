﻿using CalculateSalaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Model
{
    abstract public class Employee
    {
        public Employee(string name, decimal salary)
        {
            LastName = name;           
            Salary = salary;

        }

        //TODO: Проверка
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public abstract string GetPersonalData(char delimiter);


    }
}
