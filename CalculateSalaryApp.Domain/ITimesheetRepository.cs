using CalculateSalaryApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.Domain
{
    public interface ITimesheetRepository
    {
        void Add(TimeLog timeLog);
        TimeLog[] GetTimeLogs(string lastName);


    }
}
