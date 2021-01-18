using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSalaryApp.CMD
{
    static class Settings
    {
        public enum DirectorMenuItem
        {
            AddEmployee = 1,
            AddTimeLog,
            GetTotalReport,
            GetConcreteReport,
            Exit
        }

        public enum DirectorAddEmployeeMenuItem
        {
            AddDirector = 1,
            AddProger,
            AddFreelancer,
            Back
        }
    }
}
