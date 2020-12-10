using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp
{
    static class Settings
    {
        public const string directorsFile = "directors.json";
        public const string progersFile = "progers.json";
        public const string freelancerFile = "freelancers.json";
        public const int WorkHoursInMonth = 160;
        public const int WorkDaysInMonth = 20;
        public const int WorkHoursInDay = 8;

    }
    enum AddOperation
    {
        AddDirector = 1,
        AddProger,
        AddFreelancer
    }

    enum DirectorMenuOperation
    {
        AddUser = 1,
        ShowReportForAll,
        ShowReportForSpecific,
        AddHours,
        DeleteEmployee,
        Exit

    }
}
